/*
 * Authoer: Jiulin Hu (tohujiulin@126.com Beijing Normal University)
 * Version: 1.0
 * Description: Data Visulation from AcitViz
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

using Kitware.VTK;

namespace DataVisualization_3D
{
    public partial class DataVisualization_3D : Form
    {
        #region Common parameters
        private string m_FileName;
        private vtkRenderWindow m_RenderWindow = null;
        private vtkRenderer m_Renderer = null;
        private vtkRenderWindowInteractor Interactor = null;
        private vtkOrientationMarkerWidget axesWidget = null;
        private vtkCamera m_Camera = null;
        private bool isWander = false;
        private List<vtkProp3D> imgPropList = new List<vtkProp3D>();
        #endregion

        #region Slicer parameters
        private vtkRenderWindow m_SliceRenderWindow = null;
        private vtkRenderer m_SliceRenderer = null;
        private vtkImageActor m_SliceImageActor = null;
        private vtkImageClip m_SliceClip = null;
        #endregion

        #region Event monitor parameters
        private Kitware.VTK.vtkObject.vtkObjectEventHandler InteractorHandler = null;
        private Kitware.VTK.vtkInteractorStyleUser UserStyle = null;
        private Kitware.VTK.vtkObject.vtkObjectEventHandler UserHandler = null;
        private Kitware.VTK.vtkOutputWindow ErrorWindow = null;
        private Kitware.VTK.vtkObject.vtkObjectEventHandler ErrorHandler = null;
        #endregion

        #region Paltform
        // Constructor
        public DataVisualization_3D()
        {
            InitializeComponent();
        }
        // Trigger hook events
        private void MainPaltform_Load(object sender, EventArgs e)
        {
            m_RenderWindow = renderWindowControl1.RenderWindow;
            m_Renderer = m_RenderWindow.GetRenderers().GetFirstRenderer();
            this.HookEvents();

        }

        // Release hook resource
        private void MainPaltform_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.UnhookEvents();
        }

        // Release resource
        private void MainPaltform_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (vtkProp3D imgProp in imgPropList)
            {
                imgProp.Dispose();
            }
            if (this.renderWindowControl1 != null)
            {
                this.renderWindowControl1.Dispose();
            }
            if (this.renderWindowControl2 != null)
            {
                this.renderWindowControl2.Dispose();
            }
            if (this.Interactor != null)
            {
                this.Interactor.Dispose();
            }
            if (this.axesWidget != null)
            {
                this.axesWidget.Dispose();
            }
            System.GC.Collect();
        }

        // Resize window
        private void MainPaltform_SizeChanged(object sender, EventArgs e)
        {
            // Render1: 451, 399 Panle2: 327, 399
            this.renderWindowControl1.Width = (int)(451.0 * this.Size.Width / 800);
            //this.renderWindowControl1.Height = (int)(399.0 * this.Size.Height / 600);

            this.panel2.Width = (int)(327.0 * this.Size.Width / 800);
            //this.panel2.Height = (int)(399.0 * this.Size.Height / 600);
        }

        #endregion

        #region File
        // Open file
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Get the name of the file you want to open from the dialog 
                    m_FileName = openFileDialog.FileName;

                    //Look at known file types to see if they are readable
                    if (m_FileName.Contains(".png")
                        || m_FileName.Contains(".jpg")
                        || m_FileName.Contains(".jpeg")
                        || m_FileName.Contains(".tif")
                        || m_FileName.Contains(".slc")
                        || m_FileName.Contains(".dicom")
                        || m_FileName.Contains(".minc")
                        || m_FileName.Contains(".bmp")
                        || m_FileName.Contains(".pmn"))
                    {
                        RenderImage();
                    }
                    else if (m_FileName.Contains(".raw"))
                    {
                        RenderRaw();
                    }
                    //.vtk files need a DataSetReader instead of a ImageReader2
                    //some .vtk files need a different kind of reader, but this
                    //will read most and serve our purposes
                    else if (m_FileName.Contains(".vtk"))
                    {
                        RenderVTK();
                    }
                    else if (m_FileName.Contains(".vti"))
                    {
                        RenderVTI();
                    }
                    else if (m_FileName.Contains(".vtu"))
                    {
                        RenderVTU();
                    }
                    else if (m_FileName.Contains(".vtp"))
                    {
                        RenderVTP();
                    }
                    else if (m_FileName.Contains(".dem"))
                    {
                        RenderDEM();
                    }
                    else if (m_FileName.Contains(".xyzc"))
                    {
                        RenderXYZColor();
                    }
                    else if (m_FileName.Contains(".xyz"))
                    {
                        RenderXYZ();
                    }
                    else
                    {
                        MessageBox.Show("Warning: not support the format file.\n" +
                                        "Support: image, .raw, .vtk, .vti, .vtu, .vtp\n");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        
        #region Render for file format
        private void RenderImage()
        {
            Kitware.VTK.vtkImageReader2 rdr =
            Kitware.VTK.vtkImageReader2Factory.CreateImageReader2(m_FileName);
            rdr.SetFileName(m_FileName);
            rdr.Update();
            vtkProp3D imgProp = vtkImageActor.New();
            ((vtkImageActor)imgProp).SetInput(rdr.GetOutput());
            rdr.Dispose();

            imgPropList.Add(imgProp);
            m_Renderer.AddActor(imgProp);
            //Reset the camera to show the image
            //Equivilant of pressing 'r'
            m_Renderer.ResetCamera();
            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        private void RenderRaw()
        {
            // Read the file
            vtkParticleReader reader = vtkParticleReader.New();
            reader.SetFileName(m_FileName);
            reader.SetDataByteOrderToBigEndian();
            reader.Update();
            //MessageBox.Show("NumberOfPieces: " + reader.GetOutput().GetNumberOfPieces());

            // Visualize
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(reader.GetOutputPort());
            mapper.SetScalarRange(4, 9);
            mapper.SetPiece(1);

            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            actor.GetProperty().SetPointSize(4);
            actor.GetProperty().SetColor(1, 0, 0);

            imgPropList.Add(actor);
            // add our actor to the renderer
            m_Renderer.AddActor(actor);

            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        private void RenderVTK()
        {
            vtkDataSetReader dataReader = vtkDataSetReader.New();
            vtkDataSetMapper dataMapper = vtkDataSetMapper.New();
            vtkProp3D imgProp = vtkActor.New();
            dataReader.SetFileName(m_FileName);
            dataReader.Update();
            dataMapper.SetInput(dataReader.GetOutput());
            ((vtkActor)imgProp).SetMapper(dataMapper);
            dataMapper.Dispose();
            dataMapper = null;
            dataReader.Dispose();
            dataReader = null;

            imgPropList.Add(imgProp);
            m_Renderer.AddActor(imgProp);
            //Reset the camera to show the image
            //Equivilant of pressing 'r'
            m_Renderer.ResetCamera();
            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        private void RenderVTI()
        {
            // reader
            // Read all the data from the file
            vtkXMLImageDataReader reader = vtkXMLImageDataReader.New();
            if (reader.CanReadFile(m_FileName) == 0)
            {
                MessageBox.Show("Cannot read file \"" + m_FileName + "\"", "Error", MessageBoxButtons.OK);
                return;
            }
            vtkVolume vol = vtkVolume.New();
            vtkColorTransferFunction ctf = vtkColorTransferFunction.New();
            vtkPiecewiseFunction spwf = vtkPiecewiseFunction.New();
            vtkPiecewiseFunction gpwf = vtkPiecewiseFunction.New();

            reader.SetFileName(m_FileName);
            reader.Update(); // here we read the file actually

            // mapper
            vtkFixedPointVolumeRayCastMapper mapper = vtkFixedPointVolumeRayCastMapper.New();
            mapper.SetInputConnection(reader.GetOutputPort());

            // actor
            vtkActor actor = vtkActor.New();
            //actor.SetMapper(mapper);
            actor.GetProperty().SetRepresentationToWireframe();

            // add our actor to the renderer
            //Set the color curve for the volume
            ctf.AddHSVPoint(0, .67, .07, 1);
            ctf.AddHSVPoint(94, .67, .07, 1);
            ctf.AddHSVPoint(139, 0, 0, 0);
            ctf.AddHSVPoint(160, .28, .047, 1);
            ctf.AddHSVPoint(254, .38, .013, 1);

            //Set the opacity curve for the volume
            spwf.AddPoint(84, 0);
            spwf.AddPoint(151, .1);
            spwf.AddPoint(255, 1);

            //Set the gradient curve for the volume
            gpwf.AddPoint(0, .2);
            gpwf.AddPoint(10, .2);
            gpwf.AddPoint(25, 1);

            vol.GetProperty().SetColor(ctf);
            vol.GetProperty().SetScalarOpacity(spwf);
            vol.GetProperty().SetGradientOpacity(gpwf);

            vol.SetMapper(mapper);

            //Go through the Graphics Pipeline
            imgPropList.Add(vol);
            m_Renderer.AddVolume(vol);
            m_Renderer.ResetCamera();
            //renderer.AddActor(actor);
            RenderSlicer();

            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        private void RenderVTU()
        {
            // reader
            vtkXMLUnstructuredGridReader reader = vtkXMLUnstructuredGridReader.New();
            reader.SetFileName(m_FileName);
            reader.Update(); // here we read the file actually

            // mapper
            vtkDataSetMapper gridMapper = vtkDataSetMapper.New();
            gridMapper.SetInputConnection(reader.GetOutputPort());

            // actor
            vtkActor gridActor = vtkActor.New();
            gridActor.SetMapper(gridMapper);

            // add our actor to the renderer
            imgPropList.Add(gridActor);
            m_Renderer.AddActor(gridActor);

            // reposition the camera, so that actor can be fully seen
            m_Renderer.ResetCamera();

            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        private void RenderVTP() 
        {
            // reader
            // Read all the data from the file
            vtkXMLPolyDataReader reader = vtkXMLPolyDataReader.New();
            reader.SetFileName(m_FileName);
            reader.Update(); // here we read the file actually

            // mapper
            vtkDataSetMapper mapper = vtkDataSetMapper.New();
            mapper.SetInputConnection(reader.GetOutputPort());

            // actor
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);

            // add our actor to the renderer
            imgPropList.Add(actor);
            m_Renderer.AddActor(actor);
            m_Renderer.ResetCamera();

            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        private void RenderDEM()
        {
            vtkDEMReader reader = vtkDEMReader.New();
            reader.SetFileName(m_FileName);
            reader.Update();

            vtkLookupTable lut = vtkLookupTable.New();
            lut.SetHueRange(0.6, 0);
            lut.SetSaturationRange(1.0, 0);
            lut.SetValueRange(0.5, 1.0);
            double[] range = reader.GetOutput().GetScalarRange();
            lut.SetTableRange(range[0], range[1]);

            // Visualize
            vtkImageMapToColors mapColors = vtkImageMapToColors.New();
            mapColors.SetLookupTable(lut);
            mapColors.SetInputConnection(reader.GetOutputPort());

            // Create an actor
            vtkImageActor actor = vtkImageActor.New();
            actor.SetInput(mapColors.GetOutput());

            // add our actor to the renderer
            m_Renderer.AddActor(actor);
            imgPropList.Add(actor);

            m_Renderer.ResetCamera();

            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        private void RenderXYZColor()
        {
            FileStream fs = null;
            StreamReader sr = null;
            String sLineBuffer;
            String[] sXYZ;
            char[] chDelimiter = new char[] { ' ', '\t', ';' };
            double[] xyz = new double[3];
            double[] rgb = new double[3];
            vtkPoints points = vtkPoints.New();
            vtkPoints colors = vtkPoints.New();
            int cnt = 0;

            try
            {
                // in case file must be open in another application too use "FileShare.ReadWrite"
                fs = new FileStream(m_FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new StreamReader(fs);

                vtkDoubleArray colorScalor = new vtkDoubleArray();
                int n = 1;
                while (!sr.EndOfStream)
                {
                    sLineBuffer = sr.ReadLine();
                    cnt++;
                    sXYZ = sLineBuffer.Split(chDelimiter, StringSplitOptions.RemoveEmptyEntries);
                    if (sXYZ == null || sXYZ.Length != 6)
                    {
                        MessageBox.Show("data seems to be in wrong format at line " + cnt, "Format Exception", MessageBoxButtons.OK);
                        return;
                    }
                    xyz[0] = double.Parse(sXYZ[0], CultureInfo.InvariantCulture) * 11100;
                    xyz[1] = double.Parse(sXYZ[1], CultureInfo.InvariantCulture) * 11100;
                    xyz[2] = double.Parse(sXYZ[2], CultureInfo.InvariantCulture);

                    rgb[0] = double.Parse(sXYZ[0], CultureInfo.InvariantCulture);
                    rgb[1] = double.Parse(sXYZ[1], CultureInfo.InvariantCulture);
                    rgb[2] = double.Parse(sXYZ[2], CultureInfo.InvariantCulture);

                    points.InsertNextPoint(xyz[0], xyz[1], xyz[2]);
                    colors.InsertNextPoint(rgb[0], rgb[1], rgb[2]);
                    colorScalor.InsertNextTuple1(n++);
                }
                vtkPolyData polydata = vtkPolyData.New();
                polydata.SetPoints(points);               
                polydata.GetPointData().SetScalars(colorScalor); //设置点的Scalar(标量)属性

                vtkVertexGlyphFilter glyphFilter = vtkVertexGlyphFilter.New();
                glyphFilter.SetInputConnection(polydata.GetProducerPort());

                vtkLookupTable lookupTable = new vtkLookupTable();
                lookupTable.SetNumberOfColors(n);                
                // SetSetTableValue(vtkIdType  indx, double r, double g, double  b, double a);  
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    double[] tmp = colors.GetPoint(i);
                    double r = tmp[0];
                    double g = tmp[1];
                    double b = tmp[2];
                    lookupTable.SetTableValue(i, r, g, b, 1);
                }

                // Visualize
                vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
                mapper.SetInputConnection(glyphFilter.GetOutputPort());
                mapper.SetLookupTable(lookupTable);
                mapper.SetScalarRange(1, n);

                vtkActor actor = vtkActor.New();
                actor.SetMapper(mapper);
                actor.GetProperty().SetPointSize(1);
                //actor.GetProperty().SetColor(1, 0.5, 0);
                // add our actor to the renderer
                m_Renderer.AddActor(actor);
                imgPropList.Add(actor);

                m_Renderer.ResetCamera();

                //Rerender the screen
                m_RenderWindow.Render();
                m_Renderer.Render();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IOException", MessageBoxButtons.OK);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
        }
        private void RenderXYZ()
        {
            vtkSimplePointsReader reader = vtkSimplePointsReader.New();
            reader.SetFileName(m_FileName);
            reader.Update();
            // Visualize
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            mapper.SetInputConnection(reader.GetOutputPort());
            vtkActor actor = vtkActor.New();
            actor.SetMapper(mapper);
            actor.GetProperty().SetPointSize(2);
            m_Renderer.AddActor(actor);
            imgPropList.Add(actor);

            m_Renderer.ResetCamera();

            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        #endregion

        #endregion

        #region View
        private void eventWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.eventWindowToolStripMenuItem.Checked = !this.eventWindowToolStripMenuItem.Checked;
            this.textEvents.Visible = this.eventWindowToolStripMenuItem.Checked;
        }
        
        private void dWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dWindowToolStripMenuItem.Checked = !this.dWindowToolStripMenuItem.Checked;
            this.panel2.Visible = this.dWindowToolStripMenuItem.Checked;
            if (this.panel2.Visible)
            {
                this.renderWindowControl1.Dock = DockStyle.Left;
            }
            else
            {
                this.renderWindowControl1.Dock = DockStyle.Fill;
            }
        }

        #endregion

        #region Event monitor
        void ErrorWindow_ErrorHandler(Kitware.VTK.vtkObject sender, Kitware.VTK.vtkObjectEventArgs e)
        {
            string s = "unknown";
            if (e.CallData != IntPtr.Zero)
            {
                s = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(e.CallData);
            }

            System.Diagnostics.Debug.Write(System.String.Format(
              "ErrorWindow_ErrorHandler called: sender='{0}' e='{1}' s='{2}'", sender, e, s));
        }

        private void HookErrorWindowEvents()
        {
            if (null == this.ErrorWindow)
            {
                this.ErrorWindow = Kitware.VTK.vtkOutputWindow.GetInstance();
                this.ErrorHandler = new Kitware.VTK.vtkObject.vtkObjectEventHandler(ErrorWindow_ErrorHandler);

                this.ErrorWindow.ErrorEvt += this.ErrorHandler;
            }
        }

        public void HookEvents()
        {
            this.HookErrorWindowEvents();

            this.Interactor = this.renderWindowControl1.RenderWindow.GetInteractor();
            this.InteractorHandler = new Kitware.VTK.vtkObject.vtkObjectEventHandler(Interactor_AnyEventHandler);
            this.Interactor.AnyEvt += this.InteractorHandler;

            // Give our own style a higher priority than the built-in one
            // so that we see the events first:
            //
            float builtInPriority = this.Interactor.GetInteractorStyle().GetPriority();

            this.UserStyle = Kitware.VTK.vtkInteractorStyleUser.New();
            this.UserStyle.SetPriority(0.5f);
            this.UserStyle.SetInteractor(this.Interactor);

            this.UserHandler = new Kitware.VTK.vtkObject.vtkObjectEventHandler(UserStyle_MultipleEventHandler);

            // Keyboard events:
            this.UserStyle.KeyPressEvt += this.UserHandler;
            this.UserStyle.CharEvt += this.UserHandler;
            this.UserStyle.KeyReleaseEvt += this.UserHandler;
        }

        public void UnhookEvents()
        {
            this.UserStyle.KeyPressEvt -= this.UserHandler;
            this.UserStyle.CharEvt -= this.UserHandler;
            this.UserStyle.KeyReleaseEvt -= this.UserHandler;

            this.Interactor.AnyEvt -= this.InteractorHandler;

            this.UserHandler = null;
            this.UserStyle = null;
            this.InteractorHandler = null;
            this.Interactor = null;
        }

        void PrintEvent(Kitware.VTK.vtkObject sender, Kitware.VTK.vtkObjectEventArgs e)
        {
            int[] pos = this.Interactor.GetEventPosition();
            string keysym = this.Interactor.GetKeySym();
            sbyte keycode = this.Interactor.GetKeyCode();

            string line = String.Format("{0} ({1},{2}) ('{3}',{4}) {5} data='0x{6:x8}'{7}",
              Kitware.VTK.vtkCommand.GetStringFromEventId(e.EventId),
              pos[0], pos[1],
              keysym, keycode,
              e.Caller.GetClassName(), e.CallData.ToInt32(), System.Environment.NewLine);

            System.Diagnostics.Debug.Write(line);
            this.textEvents.AppendText(line);
        }

        void UserStyle_MultipleEventHandler(Kitware.VTK.vtkObject sender, Kitware.VTK.vtkObjectEventArgs e)
        {
            string keysym = this.Interactor.GetKeySym();

            Kitware.VTK.vtkCommand.EventIds eid = (Kitware.VTK.vtkCommand.EventIds)e.EventId;

            switch (eid)
            {
                case Kitware.VTK.vtkCommand.EventIds.KeyPressEvent:
                case Kitware.VTK.vtkCommand.EventIds.CharEvent:
                case Kitware.VTK.vtkCommand.EventIds.KeyReleaseEvent:
                    if (keysym == "f")
                    {
                        // Temporarily disable the interactor, so that the built-in 'f'
                        // handler does not get called:
                        //
                        this.Interactor.Disable();

                        // Turn on the timer, so we can re-enable the interactor
                        // after the processing of this event is over (one tenth
                        // of a second later...)
                        //
                        this.timer1.Enabled = true;
                    }
                    if (keysym.ToLower() == "j" || keysym.ToLower() == "k" || keysym.ToLower() == "l" || keysym.ToLower() == "i")
                    {
                        WanderCamera(keysym);
                    }
                    break;
            }

            this.PrintEvent(sender, e);
        }

        void Interactor_AnyEventHandler(Kitware.VTK.vtkObject sender, Kitware.VTK.vtkObjectEventArgs e)
        {
            this.PrintEvent(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Re-enable the interactor:
            //
            this.Interactor.Enable();

            // Disable the timer, so it's not continually firing:
            //
            this.timer1.Enabled = false;
        }

        #endregion

        #region Slicer control
        void RenderSlicer()
        {
            //Create all the objects for the pipeline
            vtkXMLImageDataReader reader = vtkXMLImageDataReader.New();
            vtkImageActor iactor = vtkImageActor.New();
            vtkImageClip clip = vtkImageClip.New();
            vtkContourFilter contour = vtkContourFilter.New();
            vtkPolyDataMapper mapper = vtkPolyDataMapper.New();
            vtkActor actor = vtkActor.New();
            vtkInteractorStyleImage style = vtkInteractorStyleImage.New();

            vtkRenderer renderer = renderWindowControl2.RenderWindow.GetRenderers().GetFirstRenderer();

            //Read the Image
            reader.SetFileName(m_FileName);

            //Go through the visulization pipeline
            iactor.SetInput(reader.GetOutput());
            renderer.AddActor(iactor);
            reader.Update();
            int[] extent = reader.GetOutput().GetWholeExtent();
            iactor.SetDisplayExtent(extent[0], extent[1], extent[2], extent[3],
                        (extent[4] + extent[5]) / 2,
                        (extent[4] + extent[5]) / 2);

            clip.SetInputConnection(reader.GetOutputPort());
            clip.SetOutputWholeExtent(extent[0], extent[1], extent[2], extent[3],
                        (extent[4] + extent[5]) / 2,
                        (extent[4] + extent[5]) / 2);

            contour.SetInputConnection(clip.GetOutputPort());
            contour.SetValue(0, 100);

            mapper.SetInputConnection(contour.GetOutputPort());
            mapper.SetScalarVisibility(1);

            //Go through the graphics pipeline
            actor.SetMapper(mapper);
            actor.GetProperty().SetColor(0, 1, 0);

            renderer.AddActor(actor);

            //Give a new style to the interactor
            //vtkRenderWindowInteractor iren = renderWindowControl2.RenderWindow.GetInteractor();
            //iren.SetInteractorStyle(style);


            //Update global variables
            this.trackBar1.Maximum = extent[5];
            this.trackBar1.Minimum = extent[4];
            //this.Interactor = iren;
            this.m_SliceRenderWindow = renderWindowControl2.RenderWindow;
            this.m_SliceRenderer = renderer;
            this.m_SliceClip = clip;
            this.m_SliceImageActor = iactor;

            renderer.ResetCamera();
            this.m_SliceRenderer.ResetCameraClippingRange();
            this.m_SliceRenderWindow.Render();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (m_SliceImageActor != null)
            {
                int[] lastPos = this.Interactor.GetLastEventPosition();
                int[] size = this.m_SliceRenderWindow.GetSize();
                int[] dim = this.m_SliceImageActor.GetInput().GetDimensions();

                int newSlice = (int)(trackBar1.Value);

                if (newSlice >= 0 && newSlice < dim[2])
                {
                    this.m_SliceClip.SetOutputWholeExtent(0, dim[0] - 1, 0, dim[1] - 1, newSlice, newSlice);
                    this.m_SliceImageActor.SetDisplayExtent(0, dim[0] - 1, 0, dim[1] - 1, newSlice, newSlice);
                    this.m_SliceRenderer.ResetCameraClippingRange();
                    this.m_SliceRenderWindow.Render();
                }
            }
        }
        #endregion 

        #region Render window
        // Set background color
        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ColorDialog colorDialog1 = new System.Windows.Forms.ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                m_Renderer.SetBackground(colorDialog1.Color.R / 255.0, colorDialog1.Color.G / 255.0, colorDialog1.Color.B / 255.0);
            }
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        // ResetCamera
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != m_Renderer)
            {
                m_Renderer.ResetCamera();
                this.m_Renderer.ResetCameraClippingRange();
                this.m_RenderWindow.Render();
            }
        }
        // Set wander
        private void wanderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //camera.Zoom(10.0f); // front back
            //camera.Pitch(-10.0f); // up down
            //camera.Yaw(10.0f); // left right

            isWander = !isWander;
            this.wanderToolStripMenuItem.Checked = isWander;
            if (isWander)
            {
                m_Camera = m_Renderer.GetActiveCamera();
            }
        }
        // Wander in area
        private void WanderCamera(string dir)
        {
            if (isWander && null != m_Camera)
            {
                switch (dir)
                {
                    case "i":
                        m_Camera.Pitch(0.4f);
                        break;
                    case "k":
                        m_Camera.Pitch(-0.4f);
                        break;
                    case "j":
                        m_Camera.Yaw(0.4f);
                        break;
                    case "l":
                        m_Camera.Yaw(-0.4f);
                        break;
                    default:
                        break;
                }
                this.m_Renderer.ResetCameraClippingRange();
                this.m_RenderWindow.Render();
            }
        }
        // Remove last actor
        private void removeLastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vtkProp3D lastVtkProp3D = imgPropList[imgPropList.Count - 1];
            imgPropList.Remove(lastVtkProp3D);

            m_Renderer.RemoveActor(lastVtkProp3D);
            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        // Clear all actors
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (vtkProp3D imgProp in imgPropList)
            {
                m_Renderer.RemoveActor(imgProp);
            }
            m_Renderer.SetBackground(0.0f, 0.0f, 0.0f);
            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        // Draw xyz axis
        private void xyzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == axesWidget)
            {
                vtkAxesActor axes = new vtkAxesActor();
                axesWidget = new vtkOrientationMarkerWidget();
                axesWidget.SetOutlineColor(0.9300, 0.5700, 0.1300);
                axesWidget.SetOrientationMarker(axes);
                axesWidget.SetInteractor(Interactor);
                axesWidget.SetViewport(0.0, 0.0, 0.2, 0.2);
                axesWidget.SetEnabled(1);
                axesWidget.InteractiveOn();

                // Begin mouse interaction  
                Interactor.Start();
            }
            else if (axesWidget.GetEnabled() != 0)
            {
                axesWidget.EnabledOff();
            }
            else
            {
                axesWidget.EnabledOn();
            }
            m_Renderer.ResetCamera();
            m_RenderWindow.Render();
        }
        #endregion

        #region Demo
        // Draw poly data: earth demo
        private void earthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vtkEarthSource source = new vtkEarthSource();
            vtkPolyDataMapper map = vtkPolyDataMapper.New();
            vtkPolyData poly = new vtkPolyData();
            vtkActor actor = new vtkActor();

            vtkPoints pts = new vtkPoints();
            vtkCellArray strip = new vtkCellArray();
            // 定义三个点
            pts.InsertNextPoint(0, 0, 0);
            pts.InsertNextPoint(1, 0, 0);
            pts.InsertNextPoint(1, 1, 0);

            // 定义一个单元
            strip.InsertCellPoint(3);
            strip.InsertNextCell(0);
            strip.InsertNextCell(1);
            strip.InsertNextCell(2);
            // 定义vtkPolyData为点集
            poly.SetPoints(pts);
            poly.SetVerts(strip);// 用SetVerts函数定义点, Verts即Vertices(顶点,Vertex的复数)
            // 定义mapper
            map.SetInput(poly);
            map.SetInput(source.GetOutput());
            actor.SetMapper(map);
            m_Renderer.SetBackground(.5, .5, 1);
            imgPropList.Add(actor);
            m_Renderer.AddActor(actor);
            //Rerender the screen
            m_RenderWindow.Render();
            m_Renderer.Render();
        }
        #endregion

    }
}
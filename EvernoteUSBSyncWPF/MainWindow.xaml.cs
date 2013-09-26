using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EvernoteUSBSyncLib.EvernoteReader;
using EvernoteUSBSyncLib.EvernoteWriter;

namespace EvernoteUSBSyncWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Sync to USB
        private void Button_Sync_To_Usb_Click(object sender, RoutedEventArgs e)
        {
            string message;
            try
            {
                var localFolderReader = new EvernoteReader();
                var localfiles = localFolderReader.ReadFromLocalEvernoteFolder();
                var usbWriter = new EvernoteWriter();
                message = usbWriter.WriteToUSB(localfiles)
                              ? "Successfully Synchronized with USB"
                              : "Error while synchronizing with USB";
            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            MessageBox.Show(message);
        }

        // Sync to Local
        private void Button_Sync_To_Local_Click(object sender, RoutedEventArgs e)
        {
            string message;
            try
            {
                var usbReader = new EvernoteReader();
                var localfiles = usbReader.ReadFromUSB();

                var localFolderWriter = new EvernoteWriter();
                message = localFolderWriter.WriteToEvernoteLocalFolder(localfiles)
                              ? "Successfully Synchronized with USB"
                              : "Error while synchronizing with USB";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }
    }
}

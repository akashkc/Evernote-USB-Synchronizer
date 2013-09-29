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
            Button button = (Button) sender;
            button.IsEnabled = false;
            string message = string.Empty;
            var localFolderReader = new EvernoteReader();
            var usbWriter = new EvernoteWriter();

            MessageBoxResult dialogResult = MessageBox.Show("This will synchronize evernote local folder database files with USB.\n\n Are you sure to sync with USB?", "Confirm Box",
                                                        MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.No)
            {
                button.IsEnabled = true;
                return;
            }

            try
            {
                var localfiles = localFolderReader.ReadFromLocalEvernoteFolder();

                message = usbWriter.WriteToUSB(localfiles)
                                ? "Successfully Synchronized with USB"
                                : "Error while synchronizing with USB";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            
            MessageBox.Show(message);
            button.IsEnabled = true;
        }

        // Sync to Local
        private void Button_Sync_To_Local_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            string message = string.Empty;
            var usbReader = new EvernoteReader();
            var localFolderWriter = new EvernoteWriter();
            MessageBoxResult dialogResult = MessageBox.Show("This will synchronize USB with evernote local folder database files.\n\nAre you sure to sync with Evernote Local Database folder?",
                                                      "Confirm Box", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.No)
            {
                button.IsEnabled = true;
                return;
            }
            try
            {
                var localfiles = usbReader.ReadFromUSB();
                message = localFolderWriter.WriteToEvernoteLocalFolder(localfiles)
                                ? "Successfully Synchronized with USB"
                                : "Error while synchronizing with USB";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            
            MessageBox.Show(message);
            button.IsEnabled = true;
        }
    }
}

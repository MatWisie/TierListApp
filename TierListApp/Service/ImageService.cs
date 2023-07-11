using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TierListApp.Interfaces;

namespace TierListApp.Service
{
    public class ImageService : IImageService
    {
        public void TakeImageOfControl(object control)
        {
            try
            {
                CommonOpenFileDialog openFileDialog = new CommonOpenFileDialog();
                openFileDialog.IsFolderPicker = false;
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    FrameworkElement frameworkElement = control as FrameworkElement;
                    RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)frameworkElement.ActualWidth, (int)frameworkElement.ActualHeight, 96, 96, PixelFormats.Pbgra32);
                    renderTargetBitmap.Render(frameworkElement);
                    PngBitmapEncoder pngImage = new PngBitmapEncoder();
                    pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                    using (Stream fileStream = File.Create(openFileDialog.FileName + ".png"))
                    {
                        pngImage.Save(fileStream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

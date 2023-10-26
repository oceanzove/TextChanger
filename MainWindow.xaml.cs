using System;
using System.Collections.Generic;
using System.Drawing.Text;
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

namespace TextChanger
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Заполнение комбо бокса с шрифтами
            var installedFontCollection = new InstalledFontCollection();
            foreach (var fontFamily in installedFontCollection.Families)
            {
                cbFonts.Items.Add(fontFamily.Name);
            }
            cbFonts.SelectedItem = "Consolas";

            // Заполнение комбо бокса цветами
            var colors = typeof(Brushes).GetProperties();
            foreach (var color in colors)
            {
                cbForegroundText.Items.Add(color.Name);
                cbBackgroundText.Items.Add(color.Name);
                cbBorderColor.Items.Add(color.Name);
            }
            cbForegroundText.SelectedItem = "Black";
            cbBackgroundText.SelectedItem = "BurlyWood";
            cbBorderColor.SelectedItem = "Crimson";

            var textAlignmentCollection = typeof(TextAlignment).GetEnumNames();
            foreach (var textAlignment in textAlignmentCollection)
            {
                cbTextAlignment.Items.Add(textAlignment);
            }
            cbTextAlignment.SelectedItem= "Justify";

            // Биндинг на размер шрифта.
            Binding sliderFontChanger = new Binding();
            sliderFontChanger.Source = sValueChanger;
            sliderFontChanger.Path = new PropertyPath(Slider.ValueProperty);
            tblText.SetBinding(TextBlock.FontSizeProperty, sliderFontChanger);
            // Биндинг на размер рамки
            Binding sliderBorderThickness = new Binding();
            sliderBorderThickness.Source = sBorderThickness;
            sliderBorderThickness.Path= new PropertyPath(Slider.ValueProperty);
            bUnderText.SetBinding(Border.BorderThicknessProperty, sliderBorderThickness);
            // Биндинг на скругления углов
            Binding sliderCornerRadius = new Binding();
            sliderCornerRadius.Source = sCornerRadius;
            sliderCornerRadius.Path= new PropertyPath(Slider.ValueProperty);
            bUnderText.SetBinding(Border.CornerRadiusProperty, sliderCornerRadius);
            
           
            // Биндинг на выбор шрифта.
            Binding fontSelected = new Binding();
            fontSelected.Source = cbFonts;
            fontSelected.Path = new PropertyPath(ComboBox.SelectedValueProperty);
            tblText.SetBinding (TextBlock.FontFamilyProperty, fontSelected);
            // Биндинг на выбор цвета текста. 
            Binding foregroundSelected = new Binding();
            foregroundSelected.Source = cbForegroundText;
            foregroundSelected.Path = new PropertyPath(ComboBox.SelectedValueProperty);
            tblText.SetBinding (TextBlock.ForegroundProperty, foregroundSelected);
            // Биндинг на выбор цвета фона
            Binding backgroundSelected = new Binding();
            backgroundSelected.Source = cbBackgroundText;
            backgroundSelected.Path = new PropertyPath(ComboBox.SelectedValueProperty);
            bUnderText.SetBinding(Border.BackgroundProperty, backgroundSelected);
            // Биндинг на выбор вырвнивания
            Binding alignmentSelected = new Binding();
            alignmentSelected.Source = cbTextAlignment;
            alignmentSelected.Path = new PropertyPath(ComboBox.SelectedValueProperty);
            tblText.SetBinding(TextBlock.TextAlignmentProperty, alignmentSelected);
            // Биндинг на выбор цвета рамки
            Binding borderColorSelected = new Binding();
            borderColorSelected.Source = cbBorderColor;
            borderColorSelected.Path = new PropertyPath(ComboBox.SelectedValueProperty);
            bUnderText.SetBinding(Border.BorderBrushProperty, borderColorSelected);


        }

        private void onNormalCheck(object sender, RoutedEventArgs e)
        {
            tblText.FontStyle = FontStyles.Normal;
        }
        private void onItalicCheck(object sender, RoutedEventArgs e)
        {
            tblText.FontStyle = FontStyles.Italic;
        }

        private void onWeightLight(object sender, RoutedEventArgs e)
        {
            tblText.FontWeight = FontWeights.Light;
        }

        private void onWeightNormal(object sender, RoutedEventArgs e)
        {
            tblText.FontWeight = FontWeights.Normal;
        }

        private void onWeightBold(object sender, RoutedEventArgs e)
        {
            tblText.FontWeight = FontWeights.Bold;
        }

        private void sMargin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tblText.Margin =  new Thickness(sMargin.Value);
        }
    }
}

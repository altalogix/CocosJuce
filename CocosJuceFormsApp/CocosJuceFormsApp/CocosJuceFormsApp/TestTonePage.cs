using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CocosJuceFormsApp
{
    class TestTonePage : ContentPage
    {
        private const int knobPositions = 51;
        private float frequency = 440f;
        private bool isSwitchedOn = false;
        private const float minFrequency = 0f;
        private const float frequencyStep = 40;
        private const float maxFrequency = minFrequency + (frequencyStep * knobPositions);

        private SwitchSettingView testToneSwitchView;
        private SliderSettingView frequencySliderView;

        public TestTonePage()
        {

            testToneSwitchView = new SwitchSettingView();
            testToneSwitchView.Caption.Text = "Generate Test Tone";
            testToneSwitchView.Switch.Toggled += Switch_Toggled;

            frequencySliderView = new SliderSettingView();
            frequencySliderView.Caption.Text = "Frequency";
            frequencySliderView.Value.Text = "? Hz";
            frequencySliderView.Slider.Minimum = 0;
            frequencySliderView.Slider.Maximum = knobPositions;

            frequencySliderView.Slider.ValueChanged += Slider_ValueChanged;

            var footer = new Label
            {
                Text = "CocosJuce Forms",
                FontSize = Font.SystemFontOfSize(24, FontAttributes.Bold).FontSize,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions =  LayoutOptions.EndAndExpand               
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this.Content = new StackLayout
            {

                Padding = new Thickness(0, 70, 0 , 0),
                Children =
                {
                    testToneSwitchView,
                    frequencySliderView,
                    footer,
                }
            };

            UpdateFrequency(frequency);
        }

        void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            isSwitchedOn = e.Value;
            if (isSwitchedOn)
            {
                CocosJuce.Api.StartTestTone(frequency, 0.8f);
            }
            else
            {
                CocosJuce.Api.StopTestTone();                
            }
        }

        void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            float newFreq = minFrequency + ((int)e.NewValue*frequencyStep);
            UpdateFrequency(newFreq, true);
        }

        private int lastFreqSliderValue = -1;

        void UpdateFrequency(float f, bool dontChangeSlider = false)
        {
            int newFreqSliderValue = (int)(f / frequencyStep);
            if (newFreqSliderValue != lastFreqSliderValue && newFreqSliderValue >= 0 && newFreqSliderValue < knobPositions)
            {
                lastFreqSliderValue = newFreqSliderValue;

                if (isSwitchedOn)
                {
                    CocosJuce.Api.StartTestTone(f, 0.8f);
                }

                frequencySliderView.Value.Text = minFrequency + (newFreqSliderValue * frequencyStep) + " Hz";
                if (!dontChangeSlider)
                {
                    frequencySliderView.Slider.Value = newFreqSliderValue;                    
                }
                frequency = f;
            }
        } 


    }



    public class SwitchSettingView : StackLayout
    {
        public Label Caption { get; set; }
        public Switch Switch { get; set; }

        public SwitchSettingView()
        {

            Caption = new Label()
            {
                FontSize = Font.SystemFontOfSize(18, FontAttributes.Bold).FontSize,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };


            Switch = new Switch();

            Padding = new Thickness(30, 30);
            Orientation = StackOrientation.Horizontal;
            VerticalOptions = LayoutOptions.Center;
            Children.Add(Caption);
            Children.Add(Switch);
        }
    }

    public class SliderSettingView : StackLayout
    {
        public Label Caption { get; set; }
        public Label Value { get; set; }
        public Slider Slider { get; set; }

        public SliderSettingView()
        {
            Caption = new Label()
            {
                FontSize = Font.SystemFontOfSize(18, FontAttributes.Bold).FontSize,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            Value = new Label()
            {
                FontSize = Font.SystemFontOfSize(18, FontAttributes.Bold).FontSize,
                TextColor = Color.Accent,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            Slider = new Slider()
                    {
                       VerticalOptions = LayoutOptions.CenterAndExpand,
                       HorizontalOptions =  LayoutOptions.FillAndExpand,
                        Minimum =  0,
                        Maximum = 100
                    };

            Padding = new Thickness(30, 30);
            Orientation = StackOrientation.Vertical;
            VerticalOptions = LayoutOptions.Center;

            var header = new StackLayout
                     {
                         Padding = new Thickness(0, 30),
                         Orientation = StackOrientation.Horizontal,
                         Children = {Caption, Value}
                     };
            Children.Add(header);
            Children.Add(Slider);
        }
    }

}

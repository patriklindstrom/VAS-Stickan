using System;
using System.Diagnostics;
using System.Globalization;
using MonoTouch.UIKit;
using System.Drawing;

namespace VAS_Stickan.Ipad
{
    public class MyViewController : UIViewController
    {
         UISlider _sliderVas;
        private const float SLIDER_WIDTH = 630;
        private const float SLIDER_HEIGHT = 50;
        UILabel _lblValue;
        private const float LBL_VALUE_OFFSET = 300;
        private const float LBL_VALUE_WIDTH = 50;
        private const float LBL_VALUE_HEIGHT = 50;
        UILabel _lblHeader;
        private const float LBL_HEADER_OFFSET = -300;
        private const float LBL_HEADER_WIDTH = 200;
        private const float LBL_HEADER_HEIGHT = 50;

        public MyViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            //label

            _lblHeader = new UILabel(componentRect(View.Frame, LBL_HEADER_WIDTH, LBL_HEADER_HEIGHT, LBL_HEADER_OFFSET)){               
                Text = "VAS - Stickan",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin,
                Font = UIFont.FromName("Helvetica-Bold", 40f),
                AdjustsFontSizeToFitWidth = true, // gets smaller if it doesn't fit
                LineBreakMode = UILineBreakMode.TailTruncation,
                Lines = 1, // 0 means unlimited
            };
            View.Add(_lblHeader);
            // slider
            _sliderVas = new UISlider(componentRect(View.Frame, SLIDER_WIDTH, SLIDER_HEIGHT, 0))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin,
                MinimumTrackTintColor = UIColor.Green,
                MaximumTrackTintColor = UIColor.Red,
                MinValue = 0f,
                MaxValue = 10f,
                Value = 2.5f
            };
            View.Add(_sliderVas);
            _sliderVas.ValueChanged += OnSliderValueChanged;
            //label
            _lblValue = new UILabel(componentRect(View.Frame, LBL_VALUE_WIDTH, LBL_VALUE_HEIGHT, LBL_VALUE_OFFSET)){   
                Text = "Your Pain",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |UIViewAutoresizing.FlexibleBottomMargin,
                Font = UIFont.FromName("Helvetica-Bold", 40f),
                AdjustsFontSizeToFitWidth = true, // gets smaller if it doesn't fit
                LineBreakMode = UILineBreakMode.TailTruncation,
                Lines = 1, // 0 means unlimited
            };
            View.Add(_lblValue);
          
        }

        private RectangleF componentRect(RectangleF viewFrame,float width,float height,float vOffset)
        {
            return new RectangleF(viewFrame.Width / 2 - width / 2
                , viewFrame.Height / 2 - height / 2 + vOffset
                , width, height);
        }

        private void OnSliderValueChanged(object sender, EventArgs e)
        {
            // display the value in a label
            Debug.Assert(sender.GetType() == typeof(UISlider), "A UISlider should be the caller of this delegate");
            UISlider mySlider = (UISlider)sender;

            _lblValue.Text = mySlider.Value.ToString("0.0");
        }

       
    }
}


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
        private const float LBL_VALUE_OFFSET = 100;
        private const float LBL_VALUE_WIDTH = 200;
        private const float LBL_VALUE_HEIGHT = 50;
        UIButton button;
        private float buttonOffset = 150;
        float buttonWidth = 200;
        float buttonHeight = 50;
        int numClicks = 0;

        public MyViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            // slider
            _sliderVas = new UISlider(new RectangleF(View.Frame.Width/2 - SLIDER_WIDTH/2
                , View.Frame.Height/2 - buttonHeight/2
                , SLIDER_WIDTH, SLIDER_WIDTH))
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                                   UIViewAutoresizing.FlexibleBottomMargin,
                MinimumTrackTintColor = UIColor.Green,
                MaximumTrackTintColor = UIColor.Red,
                MinValue = 0f,
                MaxValue = 10f
            };
            View.Add(_sliderVas);
            //    UISlider.Appearance.MinimumTrackTintColor = UIColor.Orange;
            //    UISlider.Appearance.MaximumTrackTintColor = UIColor.Yellow;  
            _sliderVas.Value = 2.5f; // initial value
            //label
            _lblValue = new UILabel(new RectangleF(View.Frame.Width/2 - LBL_VALUE_WIDTH/2
                , View.Frame.Height / 2 - LBL_VALUE_HEIGHT / 2 + LBL_VALUE_OFFSET
                , SLIDER_WIDTH, SLIDER_HEIGHT))
            {
                Text = "Your Pain",
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                                   UIViewAutoresizing.FlexibleBottomMargin,
                Font = UIFont.FromName("Helvetica-Bold", 40f),
                AdjustsFontSizeToFitWidth = true, // gets smaller if it doesn't fit
                LineBreakMode = UILineBreakMode.TailTruncation,
                Lines = 1, // 0 means unlimited
            };
            View.Add(_lblValue);
            button = UIButton.FromType(UIButtonType.RoundedRect);
            _sliderVas.ValueChanged += OnSliderValueChanged;
            //button
            button.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2 ,
                View.Frame.Height / 2 - buttonHeight / 2 + buttonOffset,
                buttonWidth,
                buttonHeight);
            button.SetTitle("Click me", UIControlState.Normal);
            button.TouchUpInside += OnButtonTouchUpInside;
            button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(button);
        }

        private void OnButtonTouchUpInside(object sender, EventArgs args)
        {
            Debug.Assert(sender.GetType() == typeof (UIButton),"A Button should be the caller of this delegate");
            UIButton myButton = (UIButton) sender;
            myButton.SetTitle(String.Format("clicked {0} times", numClicks++), UIControlState.Normal);
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


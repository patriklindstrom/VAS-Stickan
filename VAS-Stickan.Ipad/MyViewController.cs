using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace VAS_Stickan.Ipad
{
    public class MyViewController : UIViewController
    {
        UIButton button;
         UISlider slider;
         UILabel label;
        float sliderWidth = 200;
        float sliderHeight = 50;
        int numClicks = 0;
        float buttonWidth = 200;
        float buttonHeight = 50;

        public MyViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            label = new UILabel(new RectangleF(10, 10, 300, 30));
            label.Text = "Your Pain";
            View.Add(label);

            slider = new UISlider(new RectangleF(100, 30, 210, 20));
            View.Add(slider);
            //    UISlider.Appearance.MinimumTrackTintColor = UIColor.Orange;
            //UISlider.Appearance.MaximumTrackTintColor = UIColor.Yellow;           
            slider.MinValue = 0f;
            slider.MaxValue = 10f;
            slider.Value = 2.5f; // initial value
            button = UIButton.FromType(UIButtonType.RoundedRect);
            slider.ValueChanged += HandleValueChanged;
            button.Frame = new RectangleF(
                View.Frame.Width / 2 - buttonWidth / 2,
                View.Frame.Height / 2 - buttonHeight / 2,
                buttonWidth,
                buttonHeight);

            button.SetTitle("Click me", UIControlState.Normal);

            button.TouchUpInside += (object sender, EventArgs e) =>
            {
                button.SetTitle(String.Format("clicked {0} times", numClicks++), UIControlState.Normal);
            };

            button.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleTopMargin |
                UIViewAutoresizing.FlexibleBottomMargin;

            View.AddSubview(button);
        }

        private void HandleValueChanged(object sender, EventArgs e)
        {
            // display the value in a label
            label.Text = slider.Value.ToString();
        }

       
    }
}


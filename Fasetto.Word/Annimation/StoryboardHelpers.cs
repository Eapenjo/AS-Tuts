using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryboardHelpers
    {

        /// <summary>
        /// adds a slide from right in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to animate</param>
        /// <param name="seconds">Time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            //create the margin animate from right
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
            
            //add this to the storyboard
            storyboard.Children.Add(slideAnimation);

        }

        /// <summary>
        /// adds a slide to left in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to animate</param>
        /// <param name="seconds">Time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            //create the margin animate from right
            var slideAnimation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));

            //add this to the storyboard
            storyboard.Children.Add(slideAnimation);

        }

        /// <summary>
        /// adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to animate</param>
        /// <param name="seconds">Time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            //create the margin animate from right
            var slideAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };

            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));
            
            //add this to the storyboard
            storyboard.Children.Add(slideAnimation);

        }
        
        /// <summary>
        /// adds a fade out animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to animate</param>
        /// <param name="seconds">Time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            //create the margin animate from right
            var slideAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };

            //set the target property name
            Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));

            //add this to the storyboard
            storyboard.Children.Add(slideAnimation);

        }


    }
}

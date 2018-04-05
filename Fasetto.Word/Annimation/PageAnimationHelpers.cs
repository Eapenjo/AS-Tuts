using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{

    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimationHelpers
    {
        /// <summary>
        /// Slide a page in and fade from the right
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            //create the storyboard
            var sb = new Storyboard();

            //add slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //add fade in animation
            sb.AddFadeIn(seconds);

            //start animating
            sb.Begin(page);

            //make page visible
            page.Visibility = Visibility.Visible;

            //wait for page to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slide a page and fade out to the left
        /// </summary>
        /// <param name="page">The page to animate</param>
        /// <param name="seconds"The time the animation will take></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            //create the storyboard
            var sb = new Storyboard();

            //add slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //add fade in animation
            sb.AddFadeOut(seconds);

            //start animating
            sb.Begin(page);

            //make page visible
            page.Visibility = Visibility.Visible;

            //wait for page to finish
            await Task.Delay((int)(seconds * 1000));
        }

    }
}

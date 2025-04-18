namespace Quizzz.IRTUP.Slide_Previews
{
    internal interface IMiniSlide
    {
        void SetSlideNumber(int number);
        event EventHandler SlideClicked;
    }
}

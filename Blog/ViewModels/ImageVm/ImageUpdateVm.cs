namespace Blog.ViewModels.ImageVm
{
    public class ImageUpdateVm
    {
        public string ImageUrl { get; set; }

        public IFormFile MainImage { get; set; }
    }
}

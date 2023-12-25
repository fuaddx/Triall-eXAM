namespace Blog.ViewModels.ImageVm
{
    public class ImageCreateVm
    {
        public string ImageUrl { get; set; }

        public IFormFile? MainImage { get; set; }
    }
}

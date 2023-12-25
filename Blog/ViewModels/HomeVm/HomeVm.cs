
using Blog.ViewModels.SliderVm;
using Blog.ViewModels.ImageVm;
namespace Blog.ViewModels.HomeVm
{
    public class HomeVm
    {
        public IEnumerable<SliderListVM>Sliders { get; set; }
        public IEnumerable<ImageListVM>Images { get; set; }
    }
}
﻿
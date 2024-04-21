namespace MyRestfulApp.Application.DTOs.MercadoLibreDTOs.GetProduct
{
    /// <summary>
    /// DTO del response del método GetProduct
    /// </summary>
    public class GetProductResponseDto : BaseResponseDto
    {
        /// <summary>
        /// Product
        /// </summary>
        public ProductDto Product { get; set; }
    }
}

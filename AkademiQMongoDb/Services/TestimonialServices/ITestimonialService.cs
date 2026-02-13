using AkademiQMongoDb.Dtos.TestimonialDto;

namespace AkademiQMongoDb.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id);
        Task CreateTestimonialAsync(CreateTestimonialDto testimonialDto);
        Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteTestimonialAsync(string id);
    }
}

using AkademiQMongoDb.Dtos.TestimonialDto;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        public readonly IMapper _mapper;
        public TestimonialService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var cliemt = new MongoClient(_databaseSettings.ConnectionString);
            var database = cliemt.GetDatabase(_databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task CreateTestimonialAsync(CreateTestimonialDto testimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(testimonialDto);
            await _testimonialCollection.InsertOneAsync(testimonial);
        }

        public async Task DeleteTestimonialAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            var testimonials = await _testimonialCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(testimonials);
        }

        public async Task<GetTestimonialByIdDto> GetTestimonialByIdAsync(string id)
        {
           var testimonial = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetTestimonialByIdDto>(testimonial);
        }

        public async Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == updateTestimonialDto.TestimonialId, testimonial);
        }
    }
}

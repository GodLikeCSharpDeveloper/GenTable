using BlazorStoreServAppV5.Models.BLogicModel;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace BlazorStoreServAppV5.Repository.StoreLogic.TagRepository
{
    public class TagRepository :ITagRepository
    {
        private readonly StoreContext _storeContext;
        public TagRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<List<TagModel>> GetAllTagsAsync()
        {
            return await _storeContext.TagModels.Include(x => x.Categories).ThenInclude(x=>x.ProductModels).ToListAsync();
        }

        public async Task<TagModel> AddNewTagAsync(TagModel tagModel)
        {
            await _storeContext.TagModels.AddAsync(tagModel);
            await _storeContext.SaveChangesAsync();
            return tagModel;
        }
        //TODO MAYBE ADD SOME LOGIC OR NOT, meh WHATEVER
    }
}

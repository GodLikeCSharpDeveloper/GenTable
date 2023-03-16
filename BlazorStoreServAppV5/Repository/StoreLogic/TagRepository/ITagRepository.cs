using BlazorStoreServAppV5.Models.BLogicModel;

namespace BlazorStoreServAppV5.Repository.StoreLogic.TagRepository;

public interface ITagRepository
{
    public async Task<List<TagModel>> GetAllTagsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TagModel> AddNewTagAsync(TagModel tagModel)
    {
        throw new NotImplementedException();
    }
}
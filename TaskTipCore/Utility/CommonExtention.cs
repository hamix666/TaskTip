using AutoMapper;

namespace TaskTipCore.Utility;

public class CommonExtention
{
    public static TDto Mapto<TEntity, TDto>(TEntity entity)
    {
        var mappingConfig = new MapperConfiguration(p =>
        {
            p.CreateMap<TEntity, TDto>();
        });
        var mapper = mappingConfig.CreateMapper();
        return mapper.Map<TDto>(entity);
    }

    public static MapperConfiguration mapConfig<TEntity, TDto>()
    {
        var mappingConfig = new MapperConfiguration(p =>
        {
            p.CreateMap<TEntity, TDto>();
        });
        return mappingConfig;
    }
}
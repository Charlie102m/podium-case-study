namespace infrastructure.Profile
{
    using application.User;
    using AutoMapper;
    using domain.User;

    /// <summary>
    ///     The automapper profile.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MappingProfile" /> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
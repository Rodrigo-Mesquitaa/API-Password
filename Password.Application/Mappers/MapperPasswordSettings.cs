using AutoMapper;
using Password.Application.Dtos;
using Password.Domain;

namespace Password.Application.Mappers
{
    public class MapperPasswordSettings : Profile
    {
        public MapperPasswordSettings()
        {
            PasswordSettingsDtoToPasswordSettings();
            PasswordSettingsToPasswordSettingsDto();
        }

        private void PasswordSettingsDtoToPasswordSettings()
        {
            CreateMap<PasswordSettingsDto, PasswordSettings>()
                .ForMember(destinationMember: d => d.Id,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.Id))
                .ForMember(destinationMember: d => d.MinimumSize,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.MinimumSize))
                .ForMember(destinationMember: d => d.MaximumSize,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.MaximumSize))
                .ForMember(destinationMember: d => d.SpecialCharacterRequired,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.SpecialCharacterRequired))
                .ForMember(destinationMember: d => d.StrongPasswordRequired,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.StrongPasswordRequired))
                .ForMember(destinationMember: d => d.DateRegister,
                    memberOptions: m => m.Ignore());
        }

        private void PasswordSettingsToPasswordSettingsDto()
        {
            CreateMap<PasswordSettings, PasswordSettingsDto>()
                .ForMember(destinationMember: d => d.Id,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.Id))
                .ForMember(destinationMember: d => d.MinimumSize,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.MinimumSize))
                .ForMember(destinationMember: d => d.MaximumSize,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.MaximumSize))
                .ForMember(destinationMember: d => d.SpecialCharacterRequired,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.SpecialCharacterRequired))
                .ForMember(destinationMember: d => d.StrongPasswordRequired,
                    memberOptions: m => m.MapFrom(mapExpression: me => me.StrongPasswordRequired));
        }
    }
}
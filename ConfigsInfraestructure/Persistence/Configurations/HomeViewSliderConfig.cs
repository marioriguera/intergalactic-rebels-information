using ConfigsDomain.Entities;
using ConfigsInfraestructure.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConfigsInfraestructure.Persistence.Configurations;

/// <summary>
/// Configures the entity properties and relationships for the <see cref="HomeViewSlider"/> entity.
/// </summary>
internal class HomeViewSliderConfig : IEntityTypeConfiguration<HomeViewSlider>
{
    /// <summary>
    /// Configures the entity properties and relationships for the <see cref="HomeViewSlider"/> entity.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<HomeViewSlider> builder)
    {
        builder.ToTable(TableNames.HomeViewSliders, SchemaNames.HomeViewConfigs);

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
                .HasColumnName(nameof(HomeViewSlider.Id))
                .HasColumnType("uniqueidentifier")
                .HasColumnOrder(0)
                .ValueGeneratedNever();

        builder.Property(h => h.Src)
                .HasColumnName(nameof(HomeViewSlider.Src))
                .HasColumnType("nvarchar(500)")
                .HasColumnOrder(10)
                .IsRequired();

        builder.Property(h => h.Alt)
                .HasColumnName(nameof(HomeViewSlider.Alt))
                .HasColumnType("nvarchar(100)")
                .HasColumnOrder(20)
                .IsRequired();

        builder.HasData(
            new HomeViewSlider(Guid.NewGuid(), "https://wallpapersmug.com/download/3840x2160/d06c64/starry-space-milky-way-stars.jpg", "Wallpaper start"),
            new HomeViewSlider(Guid.NewGuid(), "https://wallpapers.com/images/hd/4k-universe-eta-carinae-nebula-2iqpijwfzmw3z4al.jpg", "Universe nebulosa"),
            new HomeViewSlider(Guid.NewGuid(), "https://wallpapers.com/images/hd/4k-space-glowing-ring-es4tss2e6i1dzfj6.jpg", "Glowing ring"));
    }
}
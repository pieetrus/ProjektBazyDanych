using BasketballLeagueDbProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballLeagueDbProject.Data;

public partial class LigaKoszykowkiContext : DbContext
{
    public LigaKoszykowkiContext()
    {
    }

    public LigaKoszykowkiContext(DbContextOptions<LigaKoszykowkiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kontrakty> Kontrakty { get; set; }

    public virtual DbSet<Ligi> Ligi { get; set; }

    public virtual DbSet<Mecze> Mecze { get; set; }

    public virtual DbSet<Nagrody> Nagrody { get; set; }

    public virtual DbSet<Pozycje> Pozycje { get; set; }

    public virtual DbSet<Sedziowie> Sedziowie { get; set; }

    public virtual DbSet<StatystykiMeczowe> StatystykiMeczowe { get; set; }

    public virtual DbSet<SystemyRozgrywek> SystemyRozgrywek { get; set; }

    public virtual DbSet<Trenerzy> Trenerzy { get; set; }

    public virtual DbSet<Turnieje> Turnieje { get; set; }

    public virtual DbSet<WynikiLigowe> WynikiLigowe { get; set; }

    public virtual DbSet<Zawodnicy> Zawodnicy { get; set; }

    public virtual DbSet<Zespoly> Zespoly { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=liga_koszykowki;MultipleActiveResultSets=true;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kontrakty>(entity =>
        {
            entity.HasKey(e => e.IdKontraktu)
                .HasName("PK_KONTRAKTY")
                .IsClustered(false);

            entity.ToTable("Kontrakty");

            entity.HasIndex(e => e.IdZawodnika, "zawodnicy_kontrakty_FK");

            entity.Property(e => e.IdKontraktu)
                .ValueGeneratedNever()
                .HasColumnName("id_kontraktu");
            entity.Property(e => e.DataPodpisania)
                .HasColumnType("datetime")
                .HasColumnName("data_podpisania");
            entity.Property(e => e.DataWygasniecia)
                .HasColumnType("datetime")
                .HasColumnName("data_wygasniecia");
            entity.Property(e => e.IdZawodnika).HasColumnName("id_zawodnika");
            entity.Property(e => e.WynagrodzenieRoczne).HasColumnName("wynagrodzenie_roczne");

            entity.HasOne(d => d.Zawodnik).WithMany(p => p.Kontrakty)
                .HasForeignKey(d => d.IdZawodnika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KONTRAKT_ZAWODNICY_ZAWODNIC");
        });

        modelBuilder.Entity<Ligi>(entity =>
        {
            entity.HasKey(e => e.IdLigi)
                .HasName("PK_LIGI")
                .IsClustered(false);

            entity.ToTable("Ligi");

            entity.HasIndex(e => e.IdNagrody, "ligi_nagrody_FK");

            entity.Property(e => e.IdLigi)
                .ValueGeneratedNever()
                .HasColumnName("id_ligi");
            entity.Property(e => e.IdNagrody).HasColumnName("id_nagrody");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");

            entity.HasOne(d => d.Nagroda).WithMany(p => p.Ligi)
                .HasForeignKey(d => d.IdNagrody)
                .HasConstraintName("FK_LIGI_LIGI_NAGR_NAGRODY");
        });

        modelBuilder.Entity<Mecze>(entity =>
        {
            entity.HasKey(e => e.IdMeczu)
                .HasName("PK_MECZE")
                .IsClustered(false);

            entity.ToTable("Mecze");

            entity.HasIndex(e => e.IdSedziego, "mecze_sedziowie_FK");

            entity.Property(e => e.IdMeczu)
                .ValueGeneratedNever()
                .HasColumnName("id_meczu");
            entity.Property(e => e.DataMeczu)
                .HasColumnType("datetime")
                .HasColumnName("data_meczu");
            entity.Property(e => e.IdSedziego).HasColumnName("id_sedziego");
            entity.Property(e => e.Miejsce)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("miejsce");

            entity.HasOne(d => d.Sedzia).WithMany(p => p.Mecze)
                .HasForeignKey(d => d.IdSedziego)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MECZE_MECZE_SED_SEDZIOWI");
        });

        modelBuilder.Entity<Nagrody>(entity =>
        {
            entity.HasKey(e => e.IdNagrody)
                .HasName("PK_NAGRODY")
                .IsClustered(false);

            entity.ToTable("Nagrody");

            entity.Property(e => e.IdNagrody)
                .ValueGeneratedNever()
                .HasColumnName("id_nagrody");
            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("opis");
        });

        modelBuilder.Entity<Pozycje>(entity =>
        {
            entity.HasKey(e => e.IdPozycji)
                .HasName("PK_POZYCJE")
                .IsClustered(false);

            entity.ToTable("Pozycje");

            entity.Property(e => e.IdPozycji)
                .ValueGeneratedNever()
                .HasColumnName("id_pozycji");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Sedziowie>(entity =>
        {
            entity.HasKey(e => e.IdSedziego)
                .HasName("PK_SEDZIOWIE")
                .IsClustered(false);

            entity.ToTable("Sedziowie");

            entity.Property(e => e.IdSedziego)
                .ValueGeneratedNever()
                .HasColumnName("id_sedziego");
            entity.Property(e => e.Imie)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("imie");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nazwisko");
        });

        modelBuilder.Entity<StatystykiMeczowe>(entity =>
        {
            entity.HasKey(e => e.IdStatystyk)
                .HasName("PK_STATYSTYKI_MECZOWE")
                .IsClustered(false);

            entity.ToTable("Statystyki_meczowe");

            entity.HasIndex(e => e.IdMeczu, "mecze_statystyki_meczowe_FK");

            entity.HasIndex(e => e.IdZawodnika, "statystyki_meczowe_zawodnicy_FK");

            entity.Property(e => e.IdStatystyk)
                .ValueGeneratedNever()
                .HasColumnName("id_statystyk");
            entity.Property(e => e.IdMeczu).HasColumnName("id_meczu");
            entity.Property(e => e.IdZawodnika).HasColumnName("id_zawodnika");
            entity.Property(e => e.LiczbaAsyst).HasColumnName("liczba_asyst");
            entity.Property(e => e.LiczbaBlokow).HasColumnName("liczba_blokow");
            entity.Property(e => e.LiczbaPrzechwytow).HasColumnName("liczba_przechwytow");
            entity.Property(e => e.LiczbaPunktow).HasColumnName("liczba_punktow");
            entity.Property(e => e.LiczbaZbiorek).HasColumnName("liczba_zbiorek");

            entity.HasOne(d => d.Mecz).WithMany(p => p.StatystykiMeczowe)
                .HasForeignKey(d => d.IdMeczu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STATYSTY_MECZE_STA_MECZE");

            entity.HasOne(d => d.Zawodnik).WithMany(p => p.StatystykiMeczowe)
                .HasForeignKey(d => d.IdZawodnika)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STATYSTY_STATYSTYK_ZAWODNIC");
        });

        modelBuilder.Entity<SystemyRozgrywek>(entity =>
        {
            entity.HasKey(e => e.IdSystemuRozgrywek)
                .HasName("PK_SYSTEMY_ROZGRYWEK")
                .IsClustered(false);

            entity.ToTable("Systemy_rozgrywek");

            entity.Property(e => e.IdSystemuRozgrywek)
                .ValueGeneratedNever()
                .HasColumnName("id_systemu_rozgrywek");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<Trenerzy>(entity =>
        {
            entity.HasKey(e => e.IdTrenera)
                .HasName("PK_TRENERZY")
                .IsClustered(false);

            entity.ToTable("Trenerzy");

            entity.Property(e => e.IdTrenera)
                .ValueGeneratedNever()
                .HasColumnName("id_trenera");
            entity.Property(e => e.DataUrodzenia)
                .HasColumnType("datetime")
                .HasColumnName("data_urodzenia");
            entity.Property(e => e.Imie)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("imie");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nazwisko");
        });

        modelBuilder.Entity<Turnieje>(entity =>
        {
            entity.HasKey(e => e.IdTurnieju)
                .HasName("PK_TURNIEJE")
                .IsClustered(false);

            entity.ToTable("Turnieje");

            entity.HasIndex(e => e.IdSystemuRozgrywek, "turnieje_systemy_rozgywek_FK");

            entity.Property(e => e.IdTurnieju)
                .ValueGeneratedNever()
                .HasColumnName("id_turnieju");
            entity.Property(e => e.IdSystemuRozgrywek).HasColumnName("id_systemu_rozgrywek");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");
            entity.Property(e => e.Opis)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("opis");
            entity.Property(e => e.RokRozpoczecia)
                .HasColumnType("datetime")
                .HasColumnName("rok_rozpoczecia");
            entity.Property(e => e.RokZakonczenia)
                .HasColumnType("datetime")
                .HasColumnName("rok_zakonczenia");

            entity.HasOne(d => d.SystemyRozgrywek).WithMany(p => p.Turnieje)
                .HasForeignKey(d => d.IdSystemuRozgrywek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TURNIEJE_TURNIEJE__SYSTEMY_");

            entity.HasMany(d => d.Zespoly).WithMany(p => p.Turnieje)
                .UsingEntity<Dictionary<string, object>>(
                    "ZespolyTurnieje",
                    r => r.HasOne<Zespoly>().WithMany()
                        .HasForeignKey("IdZespolu")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ZESPOLY__TURNIEJE__ZESPOLY"),
                    l => l.HasOne<Turnieje>().WithMany()
                        .HasForeignKey("IdTurnieju")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ZESPOLY__TURNIEJE__TURNIEJE"),
                    j =>
                    {
                        j.HasKey("IdTurnieju", "IdZespolu").HasName("PK_ZESPOLY_TURNIEJE");
                        j.ToTable("Zespoly_turnieje");
                        j.HasIndex(new[] { "IdZespolu" }, "turnieje_zespoly2_FK");
                        j.HasIndex(new[] { "IdTurnieju" }, "turnieje_zespoly_FK");
                        j.IndexerProperty<int>("IdTurnieju").HasColumnName("id_turnieju");
                        j.IndexerProperty<int>("IdZespolu").HasColumnName("id_zespolu");
                    });
        });

        modelBuilder.Entity<WynikiLigowe>(entity =>
        {
            entity.HasKey(e => new { e.IdLigi, e.IdZespolu }).HasName("PK_WYNIKI_LIGOWE");

            entity.ToTable("Wyniki_ligowe");

            entity.HasIndex(e => e.IdZespolu, "ligi_zespoly2_FK");

            entity.HasIndex(e => e.IdLigi, "ligi_zespoly_FK");

            entity.Property(e => e.IdLigi).HasColumnName("id_ligi");
            entity.Property(e => e.IdZespolu).HasColumnName("id_zespolu");
            entity.Property(e => e.LiczbaPrzegranych).HasColumnName("liczba_przegranych");
            entity.Property(e => e.LiczbaWygranych).HasColumnName("liczba_wygranych");
            entity.Property(e => e.MiejsceWTabeli).HasColumnName("miejsce_w_tabeli");

            entity.HasOne(d => d.Liga).WithMany(p => p.WynikiLigowes)
                .HasForeignKey(d => d.IdLigi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WYNIKI_L_LIGI_ZESP_LIGI");

            entity.HasOne(d => d.Zespol).WithMany(p => p.WynikiLigowe)
                .HasForeignKey(d => d.IdZespolu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WYNIKI_L_LIGI_ZESP_ZESPOLY");
        });

        modelBuilder.Entity<Zawodnicy>(entity =>
        {
            entity.HasKey(e => e.IdZawodnika)
                .HasName("PK_ZAWODNICY")
                .IsClustered(false);

            entity.ToTable("Zawodnicy");

            entity.HasIndex(e => e.IdPozycji, "zawodnicy_pozycje_FK");

            entity.HasIndex(e => e.IdZespolu, "zawodnicy_zespoly_FK");

            entity.Property(e => e.IdZawodnika)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_zawodnika");

            entity.Property(e => e.DataUrodzenia)
                .HasColumnType("datetime")
                .HasColumnName("data_urodzenia");
            entity.Property(e => e.IdPozycji).HasColumnName("id_pozycji");
            entity.Property(e => e.IdZespolu).HasColumnName("id_zespolu");
            entity.Property(e => e.Imie)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("imie");
            entity.Property(e => e.Nazwisko)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("nazwisko");
            entity.Property(e => e.Waga)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("waga");
            entity.Property(e => e.Wzrost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("wzrost");

            entity.HasOne(d => d.Pozycja).WithMany(p => p.Zawodnicy)
                .HasForeignKey(d => d.IdPozycji)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZAWODNIC_ZAWODNICY_POZYCJE");

            entity.HasOne(d => d.Zespol).WithMany(p => p.Zawodnicy)
                .HasForeignKey(d => d.IdZespolu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZAWODNIC_ZAWODNICY_ZESPOLY");
        });

        modelBuilder.Entity<Zespoly>(entity =>
        {
            entity.HasKey(e => e.IdZespolu)
                .HasName("PK_ZESPOLY")
                .IsClustered(false);

            entity.ToTable("Zespoly");

            entity.HasIndex(e => e.IdTrenera, "zespoly_trenerzy_FK");

            entity.Property(e => e.IdZespolu)
                .ValueGeneratedNever()
                .HasColumnName("id_zespolu");
            entity.Property(e => e.IdTrenera).HasColumnName("id_trenera");
            entity.Property(e => e.Nazwa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");
            entity.Property(e => e.RokZalozenia).HasColumnName("rok_zalozenia");

            entity.HasOne(d => d.Trener).WithMany(p => p.Zespoly)
                .HasForeignKey(d => d.IdTrenera)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZESPOLY_ZESPOLY_T_TRENERZY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

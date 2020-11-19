using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BibliotecaCUNOR.Models
{
    public partial class bd_bibliotecaContext : DbContext
    {
        public bd_bibliotecaContext()
        {
        }

        public bd_bibliotecaContext(DbContextOptions<bd_bibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asesor> Asesor { get; set; }
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<BitacoraLibro> BitacoraLibro { get; set; }
        public virtual DbSet<BitacoraTrabajo> BitacoraTrabajo { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<CatTrabajoGraduacion> CatTrabajoGraduacion { get; set; }
        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<DetPrestamo> DetPrestamo { get; set; }
        public virtual DbSet<Edicion> Edicion { get; set; }
        public virtual DbSet<EdicionLibro> EdicionLibro { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<LibroAutor> LibroAutor { get; set; }
        public virtual DbSet<Observacion> Observacion { get; set; }
        public virtual DbSet<PalabraClave> PalabraClave { get; set; }
        public virtual DbSet<Prestamo> Prestamo { get; set; }
        public virtual DbSet<RolUsuario> RolUsuario { get; set; }
        public virtual DbSet<TipoTrabajo> TipoTrabajo { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<TrabajoGraduacion> TrabajoGraduacion { get; set; }
        public virtual DbSet<TrabajoPalabraClave> TrabajoPalabraClave { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=159.65.75.169;Database=bd_biblioteca;Username=postgres;Password=emanuelamperez");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asesor>(entity =>
            {
                entity.HasKey(e => e.CodAsesor)
                    .HasName("Asesor_pkey");

                entity.Property(e => e.CodAsesor).HasColumnName("cod_asesor");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(150);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.CodAutor)
                    .HasName("Autor_pkey");

                entity.Property(e => e.CodAutor).HasColumnName("cod_autor");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BitacoraLibro>(entity =>
            {
                entity.HasKey(e => e.CodBitacora)
                    .HasName("Bitacora_Libro_pkey");

                entity.ToTable("Bitacora_Libro");

                entity.Property(e => e.CodBitacora).HasColumnName("cod_bitacora");

                entity.Property(e => e.Accion)
                    .IsRequired()
                    .HasColumnName("accion")
                    .HasMaxLength(50);

                entity.Property(e => e.ClaveLibro)
                    .IsRequired()
                    .HasColumnName("clave_libro")
                    .HasMaxLength(150);

                entity.Property(e => e.CodLibro).HasColumnName("cod_libro");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.TituloLibro)
                    .IsRequired()
                    .HasColumnName("titulo_libro")
                    .HasMaxLength(250);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.CodLibroNavigation)
                    .WithMany(p => p.BitacoraLibro)
                    .HasForeignKey(d => d.CodLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("libro_fkey");
            });

            modelBuilder.Entity<BitacoraTrabajo>(entity =>
            {
                entity.HasKey(e => e.CodBitacoratrabajo)
                    .HasName("BitacoraTrabajo_pkey");

                entity.HasIndex(e => e.CodRegistro)
                    .HasName("fki_bitacoratrabajo_fkey");

                entity.Property(e => e.CodBitacoratrabajo).HasColumnName("cod_bitacoratrabajo");

                entity.Property(e => e.Accion)
                    .IsRequired()
                    .HasColumnName("accion")
                    .HasMaxLength(50);

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasColumnName("autor")
                    .HasMaxLength(100);

                entity.Property(e => e.CodRegistro).HasColumnName("cod_registro");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(250);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodRegistroNavigation)
                    .WithMany(p => p.BitacoraTrabajo)
                    .HasForeignKey(d => d.CodRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bitacoratrabajo_fkey");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.CodCargo)
                    .HasName("Cargo_pkey");

                entity.Property(e => e.CodCargo).HasColumnName("cod_cargo");

                entity.Property(e => e.Cargo1)
                    .IsRequired()
                    .HasColumnName("cargo")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.CodCarrera)
                    .HasName("Carrera_pkey");

                entity.Property(e => e.CodCarrera).HasColumnName("cod_carrera");

                entity.Property(e => e.Carrera1)
                    .IsRequired()
                    .HasColumnName("carrera")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<CatTrabajoGraduacion>(entity =>
            {
                entity.HasKey(e => e.CodCat)
                    .HasName("CatTrabajoGraduacion_pkey");

                entity.Property(e => e.CodCat).HasColumnName("cod_cat");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("categoria")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.HasKey(e => e.CodClasificacion)
                    .HasName("Clasificacion_pkey");

                entity.Property(e => e.CodClasificacion).HasColumnName("cod_clasificacion");

                entity.Property(e => e.Clase)
                    .IsRequired()
                    .HasColumnName("clase")
                    .HasMaxLength(100);

                entity.Property(e => e.Clasificacion1)
                    .IsRequired()
                    .HasColumnName("clasificacion")
                    .HasMaxLength(100);

                entity.Property(e => e.CodigoClase)
                    .IsRequired()
                    .HasColumnName("codigo_clase")
                    .HasMaxLength(5);

                entity.Property(e => e.CodigoClasificacion)
                    .IsRequired()
                    .HasColumnName("codigo_clasificacion")
                    .HasMaxLength(5);

                entity.Property(e => e.CodigoDivision)
                    .IsRequired()
                    .HasColumnName("codigo_division")
                    .HasMaxLength(5);

                entity.Property(e => e.Division)
                    .IsRequired()
                    .HasColumnName("division")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DetPrestamo>(entity =>
            {
                entity.HasKey(e => e.CodDetallePrestamo)
                    .HasName("Det_Prestamo_pkey");

                entity.ToTable("Det_Prestamo");

                entity.HasIndex(e => e.CodPrestamo)
                    .HasName("fki_prestamo_fkey");

                entity.Property(e => e.CodDetallePrestamo).HasColumnName("cod_detalle_prestamo");

                entity.Property(e => e.CodLibro).HasColumnName("cod_libro");

                entity.Property(e => e.CodPrestamo).HasColumnName("cod_prestamo");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(100);

                entity.HasOne(d => d.CodLibroNavigation)
                    .WithMany(p => p.DetPrestamo)
                    .HasForeignKey(d => d.CodLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("libro_fkey");

                entity.HasOne(d => d.CodPrestamoNavigation)
                    .WithMany(p => p.DetPrestamo)
                    .HasForeignKey(d => d.CodPrestamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prestamo_fkey");
            });

            modelBuilder.Entity<Edicion>(entity =>
            {
                entity.HasKey(e => e.CodEdicion)
                    .HasName("Edicion_pkey");

                entity.Property(e => e.CodEdicion).HasColumnName("cod_edicion");

                entity.Property(e => e.Edicion1)
                    .IsRequired()
                    .HasColumnName("edicion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EdicionLibro>(entity =>
            {
                entity.HasKey(e => e.CodEdicionLibro)
                    .HasName("Edicion_Libro_pkey");

                entity.ToTable("Edicion_Libro");

                entity.HasIndex(e => e.CodEdicion)
                    .HasName("fki_edicion_fkey");

                entity.HasIndex(e => e.CodLibro)
                    .HasName("fki_libro_fkey");

                entity.Property(e => e.CodEdicionLibro).HasColumnName("cod_edicion_libro");

                entity.Property(e => e.CodEdicion).HasColumnName("cod_edicion");

                entity.Property(e => e.CodLibro).HasColumnName("cod_libro");

                entity.HasOne(d => d.CodEdicionNavigation)
                    .WithMany(p => p.EdicionLibro)
                    .HasForeignKey(d => d.CodEdicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("edicion_fkey");

                entity.HasOne(d => d.CodLibroNavigation)
                    .WithMany(p => p.EdicionLibro)
                    .HasForeignKey(d => d.CodLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("libro_fkey");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.CodEditorial)
                    .HasName("Editorial_pkey");

                entity.Property(e => e.CodEditorial).HasColumnName("cod_editorial");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.CodLibro)
                    .HasName("Libro_pkey");

                entity.HasIndex(e => e.CodClasificacion)
                    .HasName("fki_clasificacion_fkey");

                entity.HasIndex(e => e.CodEditorial)
                    .HasName("fki_editorial_fkey");

                entity.Property(e => e.CodLibro).HasColumnName("cod_libro");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(150);

                entity.Property(e => e.CodClasificacion).HasColumnName("cod_clasificacion");

                entity.Property(e => e.CodEditorial).HasColumnName("cod_editorial");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Ejemplares).HasColumnName("ejemplares");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50);

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("date");

                entity.Property(e => e.Paginas).HasColumnName("paginas");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(250);

                entity.Property(e => e.Volumen).HasColumnName("volumen");

                entity.HasOne(d => d.CodClasificacionNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.CodClasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clasificacion_fkey");

                entity.HasOne(d => d.CodEditorialNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.CodEditorial)
                    .HasConstraintName("editorial_fkey");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Libro)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_fkey");
            });

            modelBuilder.Entity<LibroAutor>(entity =>
            {
                entity.HasKey(e => e.CodLibroAutor)
                    .HasName("Libro_Autor_pkey");

                entity.ToTable("Libro_Autor");

                entity.HasIndex(e => e.CodAutor)
                    .HasName("fki_autor_fkey");

                entity.Property(e => e.CodLibroAutor).HasColumnName("cod_libro_autor");

                entity.Property(e => e.CodAutor).HasColumnName("cod_autor");

                entity.Property(e => e.CodLibro).HasColumnName("cod_libro");

                entity.HasOne(d => d.CodAutorNavigation)
                    .WithMany(p => p.LibroAutor)
                    .HasForeignKey(d => d.CodAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("autor_fkey");

                entity.HasOne(d => d.CodLibroNavigation)
                    .WithMany(p => p.LibroAutor)
                    .HasForeignKey(d => d.CodLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("libro_fkey");
            });

            modelBuilder.Entity<Observacion>(entity =>
            {
                entity.HasKey(e => e.CodObservacion)
                    .HasName("Observacion_pkey");

                entity.HasIndex(e => e.CodLibro)
                    .HasName("fki_observacion_fkey");

                entity.Property(e => e.CodObservacion).HasColumnName("cod_observacion");

                entity.Property(e => e.CodLibro).HasColumnName("cod_libro");

                entity.Property(e => e.Observacion1)
                    .IsRequired()
                    .HasColumnName("observacion")
                    .HasMaxLength(250);

                entity.HasOne(d => d.CodLibroNavigation)
                    .WithMany(p => p.Observacion)
                    .HasForeignKey(d => d.CodLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("observacion_fkey");
            });

            modelBuilder.Entity<PalabraClave>(entity =>
            {
                entity.HasKey(e => e.CodPalabraclave)
                    .HasName("PalabraClave_pkey");

                entity.Property(e => e.CodPalabraclave).HasColumnName("cod_palabraclave");

                entity.Property(e => e.PalabraClave1)
                    .IsRequired()
                    .HasColumnName("palabra_clave")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.HasKey(e => e.CodPrestamo)
                    .HasName("Prestamo_pkey");

                entity.Property(e => e.CodPrestamo).HasColumnName("cod_prestamo");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.FechaDevolucion)
                    .HasColumnName("fecha_devolucion")
                    .HasColumnType("date");

                entity.Property(e => e.FechaPrestamo)
                    .HasColumnName("fecha_prestamo")
                    .HasColumnType("date");

                entity.Property(e => e.FechaRecepcion)
                    .HasColumnName("fecha_recepcion")
                    .HasColumnType("date");

                entity.Property(e => e.Mora).HasColumnName("mora");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.Prestamo)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_fkey");
            });

            modelBuilder.Entity<RolUsuario>(entity =>
            {
                entity.HasKey(e => e.CodRolusuario)
                    .HasName("RolUsuario_pkey");

                entity.Property(e => e.CodRolusuario).HasColumnName("cod_rolusuario");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasColumnName("rol")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoTrabajo>(entity =>
            {
                entity.HasKey(e => e.CodTipotrabajo)
                    .HasName("TipoTrabajo_pkey");

                entity.Property(e => e.CodTipotrabajo).HasColumnName("cod_tipotrabajo");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.CodTipousuario)
                    .HasName("TipoUsuario_pkey");

                entity.Property(e => e.CodTipousuario).HasColumnName("cod_tipousuario");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TrabajoGraduacion>(entity =>
            {
                entity.HasKey(e => e.CodRegistro)
                    .HasName("TrabajoGraduacion_pkey");

                entity.HasIndex(e => e.CodAsesor)
                    .HasName("fki_asesor_fkey");

                entity.HasIndex(e => e.CodCarrera)
                    .HasName("fki_carrera_fkey");

                entity.HasIndex(e => e.CodCat)
                    .HasName("fki_categoria_fkey");

                entity.HasIndex(e => e.CodTipotrabajo)
                    .HasName("fki_tipotrabajo_fkey");

                entity.HasIndex(e => e.CodUsuario)
                    .HasName("fki_usuario_fkey");

                entity.Property(e => e.CodRegistro).HasColumnName("cod_registro");

                entity.Property(e => e.ApellidoAutor)
                    .IsRequired()
                    .HasColumnName("apellido_autor")
                    .HasMaxLength(50);

                entity.Property(e => e.Año).HasColumnName("año");

                entity.Property(e => e.CarnetAutor).HasColumnName("carnet_autor");

                entity.Property(e => e.CodAsesor).HasColumnName("cod_asesor");

                entity.Property(e => e.CodCarrera).HasColumnName("cod_carrera");

                entity.Property(e => e.CodCat).HasColumnName("cod_cat");

                entity.Property(e => e.CodTipotrabajo).HasColumnName("cod_tipotrabajo");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.NombreAutor)
                    .IsRequired()
                    .HasColumnName("nombre_autor")
                    .HasMaxLength(50);

                entity.Property(e => e.NombreInstitucion)
                    .HasColumnName("nombre_institucion")
                    .HasMaxLength(250);

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasMaxLength(250);

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasMaxLength(250);

                entity.Property(e => e.RecursoDigital)
                    .IsRequired()
                    .HasColumnName("recurso_digital")
                    .HasMaxLength(250);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(250);

                entity.Property(e => e.TokenRecurso)
                    .IsRequired()
                    .HasColumnName("token_recurso")
                    .HasMaxLength(250);

                entity.HasOne(d => d.CodAsesorNavigation)
                    .WithMany(p => p.TrabajoGraduacion)
                    .HasForeignKey(d => d.CodAsesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("asesor_fkey");

                entity.HasOne(d => d.CodCarreraNavigation)
                    .WithMany(p => p.TrabajoGraduacion)
                    .HasForeignKey(d => d.CodCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carrera_fkey");

                entity.HasOne(d => d.CodCatNavigation)
                    .WithMany(p => p.TrabajoGraduacion)
                    .HasForeignKey(d => d.CodCat)
                    .HasConstraintName("categoria_fkey");

                entity.HasOne(d => d.CodTipotrabajoNavigation)
                    .WithMany(p => p.TrabajoGraduacion)
                    .HasForeignKey(d => d.CodTipotrabajo)
                    .HasConstraintName("tipotrabajo_fkey");

                entity.HasOne(d => d.CodUsuarioNavigation)
                    .WithMany(p => p.TrabajoGraduacion)
                    .HasForeignKey(d => d.CodUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_fkey");
            });

            modelBuilder.Entity<TrabajoPalabraClave>(entity =>
            {
                entity.HasKey(e => e.CodTrabajoPalabraclave)
                    .HasName("Trabajo_PalabraClave_pkey");

                entity.ToTable("Trabajo_PalabraClave");

                entity.HasIndex(e => e.CodPalabraClave)
                    .HasName("fki_palabra_calve_fkey");

                entity.HasIndex(e => e.CodRegistro)
                    .HasName("fki_registro_fkey");

                entity.Property(e => e.CodTrabajoPalabraclave).HasColumnName("cod_trabajo_palabraclave");

                entity.Property(e => e.CodPalabraClave).HasColumnName("cod_palabra_clave");

                entity.Property(e => e.CodRegistro).HasColumnName("cod_registro");

                entity.HasOne(d => d.CodPalabraClaveNavigation)
                    .WithMany(p => p.TrabajoPalabraClave)
                    .HasForeignKey(d => d.CodPalabraClave)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("palabra_calve_fkey");

                entity.HasOne(d => d.CodRegistroNavigation)
                    .WithMany(p => p.TrabajoPalabraClave)
                    .HasForeignKey(d => d.CodRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registro_fkey");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario)
                    .HasName("Usuario_pkey");

                entity.HasIndex(e => e.CodRolusuario)
                    .HasName("fki_rolusuario_fkey");

                entity.HasIndex(e => e.CodTipousuario)
                    .HasName("fki_tipo_fkey");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.ActivarUsuario)
                    .HasColumnName("activar_usuario")
                    .HasMaxLength(5);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(100);

                entity.Property(e => e.CodCargo).HasColumnName("cod_cargo");

                entity.Property(e => e.CodCarrera).HasColumnName("cod_carrera");

                entity.Property(e => e.CodRolusuario).HasColumnName("cod_rolusuario");

                entity.Property(e => e.CodTipousuario).HasColumnName("cod_tipousuario");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("contraseña")
                    .HasMaxLength(250);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasColumnName("correo_electronico")
                    .HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50);

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.RecContraseña)
                    .HasColumnName("rec_contraseña")
                    .HasColumnType("character varying");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.Usuario1).HasColumnName("usuario");

                entity.HasOne(d => d.CodCarreraNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.CodCarrera)
                    .HasConstraintName("carrera_fkey");

                entity.HasOne(d => d.CodRolusuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.CodRolusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rolusuario_fkey");

                entity.HasOne(d => d.CodTipousuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.CodTipousuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tipo_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

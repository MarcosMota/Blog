namespace Blog.Core.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain;

    public partial class EfDbContext : DbContext
    {
        public EfDbContext()
            : base("name=EfDbContext")
        {
        }

        public virtual DbSet<Artigo_Comentarios> Artigo_Comentarios { get; set; }
        public virtual DbSet<Artigos> Artigos { get; set; }
        public virtual DbSet<Artigos_MetaTags> Artigos_MetaTags { get; set; }
        public virtual DbSet<Artigos_Tags> Artigos_Tags { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Configuracoes> Configuracoes { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Usuarios_Permissoes> Usuarios_Permissoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artigo_Comentarios>()
                .Property(e => e.conteudo)
                .IsUnicode(false);

            modelBuilder.Entity<Artigos>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Artigos>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Artigos>()
                .Property(e => e.meta_title)
                .IsUnicode(false);

            modelBuilder.Entity<Artigos>()
                .Property(e => e.meta_description)
                .IsUnicode(false);

            modelBuilder.Entity<Artigos>()
                .Property(e => e.conteudo)
                .IsUnicode(false);

            modelBuilder.Entity<Categorias>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Configuracoes>()
                .Property(e => e.parametro)
                .IsUnicode(false);

            modelBuilder.Entity<Configuracoes>()
                .Property(e => e.valor)
                .IsUnicode(false);

            modelBuilder.Entity<Logs>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Logs>()
                .Property(e => e.prioridade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Permissoes>()
                .Property(e => e.Nome)
                .IsUnicode(false);
            modelBuilder.Entity<Permissoes>()
                .Property(e => e.Sistema)
                .IsUnicode(false);
            modelBuilder.Entity<Permissoes>()
                .Property(e => e.Categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Tags>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.senha)
                .IsUnicode(false);
        }
    }
}

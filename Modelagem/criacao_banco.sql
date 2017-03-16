if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('artigos') and o.name = 'fk_artigos_reference_usuarios')
alter table artigos
   drop constraint fk_artigos_reference_usuarios
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('artigos') and o.name = 'fk_artigos_reference_categori')
alter table artigos
   drop constraint fk_artigos_reference_categori
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('artigos_tags') and o.name = 'fk_artigos__reference_tags')
alter table artigos_tags
   drop constraint fk_artigos__reference_tags
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('artigos_tags') and o.name = 'fk_artigos__reference_artigos')
alter table artigos_tags
   drop constraint fk_artigos__reference_artigos
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('artigo_comentarios') and o.name = 'fk_artigo_c_reference_artigos')
alter table artigo_comentarios
   drop constraint fk_artigo_c_reference_artigos
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('artigo_comentarios') and o.name = 'fk_artigo_c_reference_usuarios')
alter table artigo_comentarios
   drop constraint fk_artigo_c_reference_usuarios
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('artigo_meta_tag') and o.name = 'fk_artigo_m_reference_artigos')
alter table artigo_meta_tag
   drop constraint fk_artigo_m_reference_artigos
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('logs') and o.name = 'fk_logs_reference_usuarios')
alter table logs
   drop constraint fk_logs_reference_usuarios
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('usuarios_permissoes') and o.name = 'fk_usuarios_reference_usuarios')
alter table usuarios_permissoes
   drop constraint fk_usuarios_reference_usuarios
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('usuarios_permissoes') and o.name = 'fk_usuarios_reference_permisso')
alter table usuarios_permissoes
   drop constraint fk_usuarios_reference_permisso
go

if exists (select 1
            from  sysobjects
           where  id = object_id('artigos')
            and   type = 'U')
   drop table artigos
go

if exists (select 1
            from  sysobjects
           where  id = object_id('artigos_tags')
            and   type = 'U')
   drop table artigos_tags
go

if exists (select 1
            from  sysobjects
           where  id = object_id('artigo_comentarios')
            and   type = 'U')
   drop table artigo_comentarios
go

if exists (select 1
            from  sysobjects
           where  id = object_id('artigo_meta_tag')
            and   type = 'U')
   drop table artigo_meta_tag
go

if exists (select 1
            from  sysobjects
           where  id = object_id('categorias')
            and   type = 'U')
   drop table categorias
go

if exists (select 1
            from  sysobjects
           where  id = object_id('configuracoes')
            and   type = 'U')
   drop table configuracoes
go

if exists (select 1
            from  sysobjects
           where  id = object_id('logs')
            and   type = 'U')
   drop table logs
go

if exists (select 1
            from  sysobjects
           where  id = object_id('permissoes')
            and   type = 'U')
   drop table permissoes
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tags')
            and   type = 'U')
   drop table tags
go

if exists (select 1
            from  sysobjects
           where  id = object_id('usuarios')
            and   type = 'U')
   drop table usuarios
go

if exists (select 1
            from  sysobjects
           where  id = object_id('usuarios_permissoes')
            and   type = 'U')
   drop table usuarios_permissoes
go

/*==============================================================*/
/* Table: artigos                                               */
/*==============================================================*/
create table artigos (
   id_artigo            int                  identity,
   id_usuario           int                  null,
   id_categoria         int                  null,
   titulo               varchar(100)         null,
   descricao            varchar(400)         null,
   meta_title           varchar(100)         null,
   meta_description     varchar(100)         null,
   data_criacao         datetime             null,
   data_alteracao       datetime             null,
   conteudo             text                 null,
   ativo                bit                  null,
   constraint pk_artigos primary key (id_artigo)
)
go

/*==============================================================*/
/* Table: artigos_tags                                          */
/*==============================================================*/
create table artigos_tags (
   id_artigo_tag        int                  identity,
   id_artigo            int                  null,
   id_tag               int                  null,
   constraint pk_artigos_tags primary key (id_artigo_tag)
)
go

/*==============================================================*/
/* Table: artigo_comentarios                                    */
/*==============================================================*/
create table artigo_comentarios (
   id_artigo_comentario int                  identity,
   id_artigo            int                  null,
   id_usuario           int                  null,
   conteudo             text                 null,
   data_criacao         datetime             null,
   data_alteracao       datetime             null,
   ativo                bit                  null,
   constraint pk_artigo_comentarios primary key (id_artigo_comentario)
)
go

/*==============================================================*/
/* Table: artigo_meta_tag                                       */
/*==============================================================*/
create table artigo_meta_tag (
   id_artigo_tag        int                  identity,
   id_artigo            int                  null,
   descricao            int                  null,
   constraint pk_artigo_meta_tag primary key (id_artigo_tag)
)
go

/*==============================================================*/
/* Table: categorias                                            */
/*==============================================================*/
create table categorias (
   id_categoria         int                  identity,
   descricao            varchar(100)         null,
   constraint pk_categorias primary key (id_categoria)
)
go

/*==============================================================*/
/* Table: configuracoes                                         */
/*==============================================================*/
create table configuracoes (
   id_configuracao      int                  identity,
   parametro            varchar(100)         null,
   valor                varchar(100)         null,
   constraint pk_configuracoes primary key (id_configuracao)
)
go

/*==============================================================*/
/* Table: logs                                                  */
/*==============================================================*/
create table logs (
   id_log               int                  identity,
   id_usuario           int                  null,
   descricao            varchar(400)         null,
   data_criacao         datetime             null,
   prioridade           char(1)              null,
   constraint pk_logs primary key (id_log)
)
go

/*==============================================================*/
/* Table: permissoes                                            */
/*==============================================================*/
create table permissoes (
   id_permissao         int                  identity,
   descricao_permissao  varchar(100)         null,
   constraint pk_permissoes primary key (id_permissao)
)
go

/*==============================================================*/
/* Table: tags                                                  */
/*==============================================================*/
create table tags (
   id_tag               int                  identity,
   descricao            varchar(100)         null,
   constraint pk_tags primary key (id_tag)
)
go

/*==============================================================*/
/* Table: usuarios                                              */
/*==============================================================*/
create table usuarios (
   id_usuario           int                  identity,
   nome                 varchar(100)         null,
   email                varchar(100)         null,
   senha                varchar(100)         null,
   data_criacao         datetime             null,
   data_alteracao       datetime             null,
   ativo                bit                  null,
   constraint pk_usuarios primary key (id_usuario)
)
go

/*==============================================================*/
/* Table: usuarios_permissoes                                   */
/*==============================================================*/
create table usuarios_permissoes (
   id_permissao_usuario int                  identity,
   id_usuario           int                  null,
   id_permissao         int                  null,
   constraint pk_usuarios_permissoes primary key (id_permissao_usuario)
)
go

alter table artigos
   add constraint fk_artigos_reference_usuarios foreign key (id_usuario)
      references usuarios (id_usuario)
go

alter table artigos
   add constraint fk_artigos_reference_categori foreign key (id_categoria)
      references categorias (id_categoria)
go

alter table artigos_tags
   add constraint fk_artigos__reference_tags foreign key (id_tag)
      references tags (id_tag)
go

alter table artigos_tags
   add constraint fk_artigos__reference_artigos foreign key (id_artigo)
      references artigos (id_artigo)
go

alter table artigo_comentarios
   add constraint fk_artigo_c_reference_artigos foreign key (id_artigo)
      references artigos (id_artigo)
go

alter table artigo_comentarios
   add constraint fk_artigo_c_reference_usuarios foreign key (id_usuario)
      references usuarios (id_usuario)
go

alter table artigo_meta_tag
   add constraint fk_artigo_m_reference_artigos foreign key (id_artigo)
      references artigos (id_artigo)
go

alter table logs
   add constraint fk_logs_reference_usuarios foreign key (id_usuario)
      references usuarios (id_usuario)
go

alter table usuarios_permissoes
   add constraint fk_usuarios_reference_usuarios foreign key (id_usuario)
      references usuarios (id_usuario)
go

alter table usuarios_permissoes
   add constraint fk_usuarios_reference_permisso foreign key (id_permissao)
      references permissoes (id_permissao)
go

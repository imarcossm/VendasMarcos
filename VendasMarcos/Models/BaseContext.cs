using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VendasMarcos.Models;

public partial class BaseContext : DbContext
{
    public BaseContext()
    {
    }

    public BaseContext(DbContextOptions<BaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=base_habsoluta;Username=postgres;Password=postzeus2011");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("sql_order", new[] { "asc", "desc" })
            .HasPostgresEnum("t_comprovante_entrega_entidade_consulta", new[] { "ceecNotaFiscalSaida", "ceecPrevenda", "ceecRomaneio" })
            .HasPostgresEnum("t_consulta_nfe_distribuicao", new[] { "cndConsNSU", "cndConsChNFe" })
            .HasPostgresEnum("t_gtin_campos_produto_a_atualizar", new[] { "gcpaaCEST", "gcpaaDescricao", "gcpaaNCM" })
            .HasPostgresEnum("t_planodecontas_contas_devolucaoprevenda_data", new[] { "pcddDevolucao", "pcddPrevendaVenda", "pcddPrevendaFaturamento" })
            .HasPostgresEnum("t_planodecontas_contas_prevenda_data", new[] { "pcpdVenda", "pcpdFaturamento" })
            .HasPostgresEnum("t_planodecontas_contas_saidasnf_data", new[] { "pcsdEmissao", "pcsdFaturamento" })
            .HasPostgresEnum("t_relatorio_faturamento_custo_reposicao", new[] { "rfcrUltimoCusto", "rfcrCMV" })
            .HasPostgresEnum("t_relatorio_faturamento_movimentacao", new[] { "rfmSaidas", "rfmPrevendas" })
            .HasPostgresEnum("t_relatorio_faturamento_percentual_margem", new[] { "rfpmFaturamentoLiquido", "rfpmCustoReposicao" })
            .HasPostgresEnum("t_tipo_alteracao_movimentacao", new[] { "tamInclusao", "tamExclusao" })
            .HasPostgresEnum("t_tipo_beneficio", new[] { "tbPrecoFixo", "tbDescontoPercentual", "tbLevaPaga", "tbDescontoValor" })
            .HasPostgresEnum("t_tipo_condicao", new[] { "tcParaCada", "tcAPartirDeQuantidade" })
            .HasPostgresEnum("t_tipo_data_tributacao", new[] { "tdtEmissao", "tdtEntradaSaida" })
            .HasPostgresEnum("t_tipo_solicitacao_reenvio_scanntech", new[] { "tsrsVendas", "tsrsFechamentos" })
            .HasPostgresEnum("t_tipo_sugestao_compra", new[] { "tscAlemDoEstoqueMinimo", "tscSomenteSuficienteParaConsumoPrevisto", "tscSuprirEstoqueAteMinimoDefinidoProduto" })
            .HasPostgresEnum("t_vendas_tabelasprecos_criterio", new[] { "vtcMenorPreco", "vtcMaiorPreco" })
            .HasPostgresEnum("ttimeinterval", new[] { "tiYear", "tiMonth", "tiDay" })
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pldbgapi")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid", "uuid-ossp");

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Login, "usuarios_login_unique").IsUnique();

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Admin)
                .HasDefaultValue(false)
                .HasColumnName("admin");
            entity.Property(e => e.Baixacontas)
                .HasDefaultValue(false)
                .HasColumnName("baixacontas");
            entity.Property(e => e.Baixarcontasretroativo)
                .HasDefaultValue(false)
                .HasColumnName("baixarcontasretroativo");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(50)
                .HasColumnName("endereco");
            entity.Property(e => e.Estornaduplicata)
                .HasDefaultValue(false)
                .HasColumnName("estornaduplicata");
            entity.Property(e => e.Estornavenda)
                .HasDefaultValue(false)
                .HasColumnName("estornavenda");
            entity.Property(e => e.Faturarvendadatahoraespecifica)
                .HasDefaultValue(false)
                .HasColumnName("faturarvendadatahoraespecifica");
            entity.Property(e => e.Faturavenda)
                .HasDefaultValue(false)
                .HasColumnName("faturavenda");
            entity.Property(e => e.Gerenciapedidos)
                .HasDefaultValue(false)
                .HasColumnName("gerenciapedidos");
            entity.Property(e => e.Lastupdatepdvinfo)
                .HasDefaultValueSql("date_trunc('SECOND'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastupdatepdvinfo");
            entity.Property(e => e.Login)
                .HasMaxLength(15)
                .HasColumnName("login");
            entity.Property(e => e.Methodaccessforms)
                .HasDefaultValue(2)
                .HasComment("1 - White List, 2 - Black List")
                .HasColumnName("methodaccessforms");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .HasColumnName("nome");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("pass");
            entity.Property(e => e.Sawversionnotes)
                .HasDefaultValue(true)
                .HasColumnName("sawversionnotes");
        });
        modelBuilder.HasSequence("auditoria_chave_seq");
        modelBuilder.HasSequence("cfop_codigo_seq");
        modelBuilder.HasSequence("contasapagar_codigo_seq");
        modelBuilder.HasSequence("contasareceber_old_codigo_seq").StartsAt(1615L);
        modelBuilder.HasSequence("contribuintes_codigo_seq");
        modelBuilder.HasSequence("ecf_codigo_seq");
        modelBuilder.HasSequence("ecfprodutos_codigo_seq");
        modelBuilder.HasSequence("entradasprodnf_codigo_seq");
        modelBuilder.HasSequence("gradeproddetalhe_codigo_seq");
        modelBuilder.HasSequence("gradeproduto_codigo_seq");
        modelBuilder.HasSequence("grupos_codigo_seq");
        modelBuilder.HasSequence("historicos_codigo_seq");
        modelBuilder.HasSequence("lancamentos_codigo_seq");
        modelBuilder.HasSequence("logs_codigo_seq");
        modelBuilder.HasSequence("movimentacoes2_codigo_seq");
        modelBuilder.HasSequence("natoperacao_codigo_seq");
        modelBuilder.HasSequence("ncm_codigo_seq");
        modelBuilder.HasSequence("nfeinfo_codigo_seq");
        modelBuilder.HasSequence("prevendasprod_codigo_seq");
        modelBuilder.HasSequence("produtos_codigo_seq").StartsAt(2081L);
        modelBuilder.HasSequence("saidasnf_codigo_seq");
        modelBuilder.HasSequence("saidasprodnf_codigo_seq");
        modelBuilder.HasSequence("situacaocheque_codigo_seq");
        modelBuilder.HasSequence("situacaoconta_codigo_seq");
        modelBuilder.HasSequence("transportadoras_codigo_seq");
        modelBuilder.HasSequence("usuarios_codigo_seq");
        modelBuilder.HasSequence("vendas_codigo_seq");
        modelBuilder.HasSequence("vendasprod_codigo_seq");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

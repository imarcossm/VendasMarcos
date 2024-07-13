using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VendasMarcos.Models;

namespace VendasMarcos.TempModel;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clientes> Clientes { get; set; }
    public virtual DbSet<Produtos> Produtos { get; set; }
    public virtual DbSet<ClientesTelefones> ClientesTelefones { get; set; }

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

        modelBuilder.Entity<Produtos>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("produtos_pkey");

            entity.ToTable("produtos", tb => tb.HasComment("PRODUTOS"));

            entity.HasIndex(e => e.Codanterior, "produtos_codanterior_idx").IsUnique();

            entity.HasIndex(e => e.Codbalanca, "produtos_codbalanca_unique").IsUnique();

            entity.HasIndex(e => e.Codean, "produtos_codean_unique").IsUnique();

            entity.HasIndex(e => e.Codfabricante, "produtos_codfabricante_index");

            entity.HasIndex(e => e.Codfornecedor, "produtos_codfornecedor_index");

            entity.HasIndex(e => e.Codigo, "produtos_codigo_index");

            entity.HasIndex(e => e.Nome, "produtos_nome_index");

            entity.HasIndex(e => e.Referencia, "produtos_referencia_index");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Askdescadicional)
                .HasDefaultValue(false)
                .HasColumnName("askdescadicional");
            entity.Property(e => e.Cestcodigo)
                .HasMaxLength(7)
                .HasColumnName("cestcodigo");
            entity.Property(e => e.Clistserv)
                .HasComment("Lista de Serviços, obrigar o preenchimento caso tipoitem seja 3 (Serviços).")
                .HasColumnName("clistserv");
            entity.Property(e => e.CodTabela)
                .HasDefaultValue(33)
                .HasColumnName("cod_tabela");
            entity.Property(e => e.Codanterior)
                .HasMaxLength(13)
                .HasColumnName("codanterior");
            entity.Property(e => e.Codbalanca).HasColumnName("codbalanca");
            entity.Property(e => e.Codean)
                .HasMaxLength(14)
                .HasColumnName("codean");
            entity.Property(e => e.Codecfaliquota).HasColumnName("codecfaliquota");
            entity.Property(e => e.Codfabricante)
                .HasMaxLength(20)
                .HasColumnName("codfabricante");
            entity.Property(e => e.Codfisiografico)
                .HasMaxLength(7)
                .HasColumnName("codfisiografico");
            entity.Property(e => e.Codformula).HasColumnName("codformula");
            entity.Property(e => e.Codfornecedor).HasColumnName("codfornecedor");
            entity.Property(e => e.Codgrupo).HasColumnName("codgrupo");
            entity.Property(e => e.Codmarca).HasColumnName("codmarca");
            entity.Property(e => e.Codncm)
                .HasMaxLength(8)
                .HasColumnName("codncm");
            entity.Property(e => e.Codtributoestrutura).HasColumnName("codtributoestrutura");
            entity.Property(e => e.Cofins)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("cofins");
            entity.Property(e => e.Comissao)
                .HasPrecision(13, 3)
                .HasDefaultValueSql("0")
                .HasColumnName("comissao");
            entity.Property(e => e.Comissaovenda)
                .HasPrecision(13, 2)
                .HasColumnName("comissaovenda");
            entity.Property(e => e.Cprodanp).HasColumnName("cprodanp");
            entity.Property(e => e.Custonota)
                .HasPrecision(13, 4)
                .HasColumnName("custonota");
            entity.Property(e => e.Custopauta)
                .HasPrecision(13, 4)
                .HasColumnName("custopauta");
            entity.Property(e => e.Desativado)
                .HasDefaultValue(false)
                .HasColumnName("desativado");
            entity.Property(e => e.DescadicionalDefault).HasColumnName("descadicional_default");
            entity.Property(e => e.Descontocalc)
                .HasPrecision(13, 2)
                .HasDefaultValueSql("0")
                .HasComment("Campo que pode ser utilizado na confecção de fórmula para cálculo do preço de venda")
                .HasColumnName("descontocalc");
            entity.Property(e => e.Descontocompra)
                .HasPrecision(13, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("descontocompra");
            entity.Property(e => e.Descontomaximo)
                .HasPrecision(13, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("descontomaximo");
            entity.Property(e => e.Descontovenda)
                .HasPrecision(13, 2)
                .HasDefaultValueSql("0")
                .HasComment("Percentual a ser descontado automaticamente do preço de venda do produto em Orçamentos, Pré-Vendas e Notas Fiscais de Saída")
                .HasColumnName("descontovenda");
            entity.Property(e => e.Despesaadministrativa)
                .HasPrecision(13, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("despesaadministrativa");
            entity.Property(e => e.Diferencaicms)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("diferencaicms");
            entity.Property(e => e.ExigeSerie)
                .HasDefaultValue(false)
                .HasColumnName("exige_serie");
            entity.Property(e => e.Fatorprecovenda)
                .HasPrecision(13, 2)
                .HasColumnName("fatorprecovenda");
            entity.Property(e => e.Fracionaqtde)
                .HasDefaultValue(true)
                .HasComment("Define se a quantidade do produto pode ser fracionada nas operações de movimentação do produto")
                .HasColumnName("fracionaqtde");
            entity.Property(e => e.Frete)
                .HasPrecision(13, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("frete");
            entity.Property(e => e.Icmscredito)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("icmscredito");
            entity.Property(e => e.Icmsdebito)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("icmsdebito");
            entity.Property(e => e.Icmsreducaoentrada)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("icmsreducaoentrada");
            entity.Property(e => e.Icmsreducaosaida)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("icmsreducaosaida");
            entity.Property(e => e.Icmssubstituto)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("icmssubstituto");
            entity.Property(e => e.Impostofederal)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("impostofederal");
            entity.Property(e => e.Infcomplementar)
                .HasMaxLength(15)
                .HasColumnName("infcomplementar");
            entity.Property(e => e.Ipi)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("ipi");
            entity.Property(e => e.Lastupdatemobileinfo)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastupdatemobileinfo");
            entity.Property(e => e.Lastupdatepdvinfo)
                .HasDefaultValueSql("date_trunc('second'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastupdatepdvinfo");
            entity.Property(e => e.Margemlucro)
                .HasPrecision(13, 3)
                .HasDefaultValueSql("0")
                .HasColumnName("margemlucro");
            entity.Property(e => e.Medidagarantia).HasColumnName("medidagarantia");
            entity.Property(e => e.Medidavalidade)
                .HasMaxLength(10)
                .HasColumnName("medidavalidade");
            entity.Property(e => e.Naoinventariar)
                .HasDefaultValue(false)
                .HasColumnName("naoinventariar");
            entity.Property(e => e.Natreceita)
                .HasComment("Natureza da receita, conforme registro M410 do EFD PIS/COFINS Versão 1.03")
                .HasColumnName("natreceita");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .HasColumnName("nome");
            entity.Property(e => e.Observacao)
                .HasMaxLength(400)
                .HasColumnName("observacao");
            entity.Property(e => e.Outrasdespesas)
                .HasPrecision(13, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("outrasdespesas");
            entity.Property(e => e.Peso)
                .HasPrecision(13, 3)
                .HasColumnName("peso");
            entity.Property(e => e.Pis)
                .HasPrecision(13, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("pis");
            entity.Property(e => e.Possuiserial)
                .HasDefaultValue(false)
                .HasColumnName("possuiserial");
            entity.Property(e => e.Precoaposdesconto)
                .HasPrecision(23, 10)
                .HasDefaultValueSql("0")
                .HasColumnName("precoaposdesconto");
            entity.Property(e => e.Precoautomatico)
                .HasDefaultValue(false)
                .HasColumnName("precoautomatico");
            entity.Property(e => e.Precominimo)
                .HasPrecision(23, 10)
                .HasColumnName("precominimo");
            entity.Property(e => e.Precorecomendado)
                .HasPrecision(23, 10)
                .HasDefaultValueSql("0")
                .HasColumnName("precorecomendado");
            entity.Property(e => e.Precovenda)
                .HasPrecision(23, 10)
                .HasColumnName("precovenda");
            entity.Property(e => e.Qtdefiscal)
                .HasPrecision(15, 4)
                .HasColumnName("qtdefiscal");
            entity.Property(e => e.Qtdegarantia).HasColumnName("qtdegarantia");
            entity.Property(e => e.Qtdemin)
                .HasPrecision(15, 4)
                .HasDefaultValueSql("0")
                .HasColumnName("qtdemin");
            entity.Property(e => e.Rastreiofiscal)
                .HasDefaultValue(false)
                .HasComment("Especifica se o produto é fiscalmente rastreável")
                .HasColumnName("rastreiofiscal");
            entity.Property(e => e.Referencia)
                .HasMaxLength(120)
                .HasColumnName("referencia");
            entity.Property(e => e.Refq)
                .HasPrecision(15, 4)
                .HasColumnName("refq");
            entity.Property(e => e.Seguro)
                .HasPrecision(13, 2)
                .HasDefaultValueSql("0")
                .HasColumnName("seguro");
            entity.Property(e => e.Synctomobile)
                .HasDefaultValue(false)
                .HasColumnName("synctomobile");
            entity.Property(e => e.Tipocodbalanca)
                .HasComment("0 - Definição de quantidade na balança por peso, 1 - Definição de quantidade na balança por unidade;")
                .HasColumnName("tipocodbalanca");
            entity.Property(e => e.Tipodetalhamento)
                .HasComment("0 = Veículo Novo, 1 = Medicamentos, 2 = Armas, 3 = Combustível; Por enquanto somente o tipo Veículo Novo")
                .HasColumnName("tipodetalhamento");
            entity.Property(e => e.Tipoitem).HasColumnName("tipoitem");
            entity.Property(e => e.Unidade)
                .HasMaxLength(6)
                .HasColumnName("unidade");
            entity.Property(e => e.Validade).HasColumnName("validade");
        });

        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("clientes_pkey");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Apelido, "clientes_apelido_index");

            entity.HasIndex(e => e.Codant, "clientes_codant_unique").IsUnique();

            entity.HasIndex(e => e.Codigo, "clientes_codigo_index");

            entity.HasIndex(e => e.Nome, "clientes_nome_index");

            entity.HasIndex(e => e.Codigo, "unq_clientes").IsUnique();

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Apelido)
                .HasMaxLength(50)
                .HasColumnName("apelido");
            entity.Property(e => e.Bairro)
                .HasMaxLength(30)
                .HasColumnName("bairro");
            entity.Property(e => e.Bloqueado)
                .HasDefaultValue(false)
                .HasColumnName("bloqueado");
            entity.Property(e => e.Cep)
                .HasMaxLength(9)
                .HasColumnName("cep");
            entity.Property(e => e.CodTabela)
                .HasDefaultValue(4)
                .HasColumnName("cod_tabela");
            entity.Property(e => e.Codant).HasColumnName("codant");
            entity.Property(e => e.Codgrupo).HasColumnName("codgrupo");
            entity.Property(e => e.Codmunicipio).HasColumnName("codmunicipio");
            entity.Property(e => e.Codvendedor).HasColumnName("codvendedor");
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .HasColumnName("complemento");
            entity.Property(e => e.Contato)
                .HasMaxLength(50)
                .HasColumnName("contato");
            entity.Property(e => e.Cpais).HasColumnName("cpais");
            entity.Property(e => e.Cpfcnpj)
                .HasMaxLength(14)
                .HasColumnName("cpfcnpj");
            entity.Property(e => e.Denominacao)
                .HasMaxLength(1)
                .HasComment("1 - Jurídica, 2 - Física, 3 - Órgão Público Federal, 4 - Órgão Público Estadual, 5 - Outros")
                .HasColumnName("denominacao");
            entity.Property(e => e.Dtcadastro)
                .HasDefaultValueSql("now()")
                .HasColumnName("dtcadastro");
            entity.Property(e => e.Dtnascimento).HasColumnName("dtnascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Endereco)
                .HasMaxLength(50)
                .HasColumnName("endereco");
            entity.Property(e => e.Endereconumero)
                .HasMaxLength(10)
                .HasColumnName("endereconumero");
            entity.Property(e => e.Estcivil)
                .HasMaxLength(20)
                .HasColumnName("estcivil");
            entity.Property(e => e.Fatorpreco)
                .HasPrecision(13, 2)
                .HasColumnName("fatorpreco");
            entity.Property(e => e.Idestrangeiro)
                .HasMaxLength(20)
                .HasComment("Identificação do destinatário no caso de comprador estrangeiro. Campo para uso na NF-e")
                .HasColumnName("idestrangeiro");
            entity.Property(e => e.Ie)
                .HasMaxLength(14)
                .HasColumnName("ie");
            entity.Property(e => e.Indiedest)
                .HasComment("1 = Contribuinte ICMS; 2 = Contribuinte isento; 9 = Não Contribuinte")
                .HasColumnName("indiedest");
            entity.Property(e => e.Isuf)
                .HasMaxLength(9)
                .HasComment("Campo para informação da \"Inscrição na SUFRAMA\", conforme especificações do manual 4.01-NT2009.006 da NFE")
                .HasColumnName("isuf");
            entity.Property(e => e.Lastupdatemobileinfo)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastupdatemobileinfo");
            entity.Property(e => e.Lastupdatepdvinfo)
                .HasDefaultValueSql("date_trunc('second'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastupdatepdvinfo");
            entity.Property(e => e.Limitecredito)
                .HasPrecision(15, 2)
                .HasColumnName("limitecredito");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .HasColumnName("nome");
            entity.Property(e => e.Obs)
                .HasMaxLength(600)
                .HasColumnName("obs");
            entity.Property(e => e.Orgemissor)
                .HasMaxLength(5)
                .HasColumnName("orgemissor");
            entity.Property(e => e.RegimeTributarioParticipanteCodigo).HasColumnName("regime_tributario_participante_codigo");
            entity.Property(e => e.Repassecusto)
                .HasDefaultValue(false)
                .HasComment("Repassar o custo dos produtos em Orçamentos e Pré-Vendas")
                .HasColumnName("repassecusto");
            entity.Property(e => e.Restricao).HasColumnName("restricao");
            entity.Property(e => e.Rg)
                .HasMaxLength(14)
                .HasColumnName("rg");
            entity.Property(e => e.Semdependente)
                .HasMaxLength(1)
                .HasDefaultValueSql("'1'::bpchar")
                .HasColumnName("semdependente");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .HasColumnName("sexo");
            entity.Property(e => e.Ufemissor)
                .HasMaxLength(2)
                .HasColumnName("ufemissor");
        });

        modelBuilder.Entity<ClientesTelefones>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("clientes_telefones_pkey");

            entity.ToTable("clientes_telefones");

            entity.HasIndex(e => new { e.Codcliente, e.Ddi, e.Ddd, e.Telefone, e.Ramal }, "clientes_telefones_codcliente_ddi_ddd_telefone_ramal_idx").IsUnique();

            entity.HasIndex(e => new { e.Codcliente, e.Principal }, "clientes_telefones_codcliente_principal_idx")
                .IsUnique()
                .HasFilter("(principal = true)");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Codcliente).HasColumnName("codcliente");
            entity.Property(e => e.Ddd).HasColumnName("ddd");
            entity.Property(e => e.Ddi)
                .HasDefaultValue(55)
                .HasColumnName("ddi");
            entity.Property(e => e.Lastupdateinfo)
                .HasDefaultValueSql("date_trunc('SECOND'::text, now())")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lastupdateinfo");
            entity.Property(e => e.Principal)
                .HasDefaultValue(false)
                .HasColumnName("principal");
            entity.Property(e => e.Ramal).HasColumnName("ramal");
            entity.Property(e => e.Telefone)
                .HasMaxLength(11)
                .HasColumnName("telefone");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .HasColumnName("tipo");
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

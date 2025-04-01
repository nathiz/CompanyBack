using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyBack.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    Setor = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalhamentoProcessos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FerramentasUtilizadas = table.Column<string>(type: "text", nullable: false),
                    Responsaveis = table.Column<string>(type: "text", nullable: false),
                    DocumentacaoAssociada = table.Column<string>(type: "text", nullable: false),
                    ProcessId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalhamentoProcessos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalhamentoProcessos_Processos_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subprocessos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    ProcessId = table.Column<int>(type: "integer", nullable: false),
                    SubProcessId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subprocessos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subprocessos_Processos_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subprocessos_Subprocessos_SubProcessId",
                        column: x => x.SubProcessId,
                        principalTable: "Subprocessos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    ProcessoId = table.Column<int>(type: "integer", nullable: true),
                    SubProcessId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Documentos_Subprocessos_SubProcessId",
                        column: x => x.SubProcessId,
                        principalTable: "Subprocessos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ferramentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ProcessoId = table.Column<int>(type: "integer", nullable: true),
                    SubProcessId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferramentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ferramentas_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ferramentas_Subprocessos_SubProcessId",
                        column: x => x.SubProcessId,
                        principalTable: "Subprocessos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    ProcessoId = table.Column<int>(type: "integer", nullable: true),
                    SubProcessId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsaveis_Processos_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Responsaveis_Subprocessos_SubProcessId",
                        column: x => x.SubProcessId,
                        principalTable: "Subprocessos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalhamentoProcessos_ProcessId",
                table: "DetalhamentoProcessos",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ProcessoId",
                table: "Documentos",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_SubProcessId",
                table: "Documentos",
                column: "SubProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferramentas_ProcessoId",
                table: "Ferramentas",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferramentas_SubProcessId",
                table: "Ferramentas",
                column: "SubProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Processos_AreaId",
                table: "Processos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_ProcessoId",
                table: "Responsaveis",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_SubProcessId",
                table: "Responsaveis",
                column: "SubProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Subprocessos_ProcessId",
                table: "Subprocessos",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Subprocessos_SubProcessId",
                table: "Subprocessos",
                column: "SubProcessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalhamentoProcessos");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Ferramentas");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Subprocessos");

            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}

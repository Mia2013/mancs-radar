using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mancs_radar_server.Migrations
{
    /// <inheritdoc />
    public partial class AddDogBreeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Breed",
                table: "Dogs");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Point>(
                name: "LastSeenLocation",
                table: "Dogs",
                type: "geography",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geography");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreedType",
                table: "Dogs",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LastSeenAddressId",
                table: "Dogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DogBreed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DogSize = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogBreed", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DogBreed",
                columns: new[] { "Id", "Color", "DogSize", "Name" },
                values: new object[,]
                {
                    { 1, "[\"White\"]", "Large", "Komondor" },
                    { 2, "[\"White\"]", "Large", "Kuvasz" },
                    { 3, "[\"Black\",\"White\",\"Brown\",\"Grey\",\"Gold\"]", "Medium", "Mudi" },
                    { 4, "[\"Black\",\"White\",\"Grey\",\"Red\"]", "Medium", "Puli" },
                    { 5, "[\"Black\",\"White\",\"Grey\",\"Red\"]", "Medium", "Pumi" },
                    { 6, "[\"Gold\",\"Red\"]", "Medium", "Rövidszőrű magyar vizsla" },
                    { 7, "[\"Gold\",\"Red\"]", "Medium", "Drótszőrű magyar vizsla" },
                    { 8, "[\"Black\",\"Red\"]", "Medium", "Erdélyi kopó" },
                    { 9, "[\"Black\",\"White\",\"Grey\",\"Red\",\"Brindle\"]", "Large", "Magyar agár" },
                    { 10, "[\"Black\",\"Red\",\"Grey\"]", "Large", "Német juhászkutya" },
                    { 11, "[\"Black\"]", "Large", "Belga juhászkutya (Groenendael)" },
                    { 12, "[\"Red\",\"Grey\"]", "Large", "Belga juhászkutya (Laekenois)" },
                    { 13, "[\"Red\",\"Black\"]", "Large", "Belga juhászkutya (Malinois)" },
                    { 14, "[\"Red\",\"Grey\",\"Black\"]", "Large", "Belga juhászkutya (Tervueren)" },
                    { 15, "[\"Black\",\"White\",\"Brown\",\"Red\",\"Grey\"]", "Medium", "Border collie" },
                    { 16, "[\"Black\",\"White\",\"Red\",\"Grey\"]", "Medium", "Ausztrál juhászkutya" },
                    { 17, "[\"Black\",\"Brown\",\"Red\",\"Grey\"]", "Medium", "Ausztrál kelpie" },
                    { 18, "[\"Grey\",\"Red\",\"Black\"]", "Medium", "Ausztrál pásztorkutya" },
                    { 19, "[\"Gold\",\"White\",\"Black\",\"Grey\"]", "Large", "Hosszúszőrű skót juhászkutya" },
                    { 20, "[\"Gold\",\"White\",\"Black\",\"Grey\"]", "Large", "Rövidszőrű skót juhászkutya" },
                    { 21, "[\"Gold\",\"White\",\"Black\",\"Grey\"]", "Small", "Shetlandi juhászkutya" },
                    { 22, "[\"Red\",\"Gold\",\"Black\",\"White\"]", "Small", "Welsh corgi pembroke" },
                    { 23, "[\"Black\",\"Grey\",\"Red\",\"White\",\"Brindle\"]", "Small", "Welsh corgi cardigan" },
                    { 24, "[\"Grey\",\"White\"]", "Large", "Óangol juhászkutya (Bobtail)" },
                    { 25, "[\"White\"]", "Large", "Svájci fehér juhászkutya" },
                    { 26, "[\"Black\",\"Red\",\"Grey\"]", "Large", "Beauce-i juhászkutya (Beauceron)" },
                    { 27, "[\"Black\",\"Grey\",\"Gold\"]", "Large", "Briard" },
                    { 28, "[\"Grey\"]", "Large", "Csehszlovák farkaskutya" },
                    { 29, "[\"Grey\",\"Brown\"]", "Large", "Saarloosi farkaskutya" },
                    { 30, "[\"Grey\",\"Black\"]", "Large", "Bergamói juhászkutya" },
                    { 31, "[\"Grey\",\"Brown\",\"Black\",\"Gold\"]", "Medium", "Katalán pásztorkutya" },
                    { 32, "[\"White\",\"Grey\",\"Black\",\"Brown\"]", "Medium", "Lengyel alföldi juhászkutya" },
                    { 33, "[\"White\"]", "Large", "Tátrai juhászkutya" },
                    { 34, "[\"Black\"]", "Medium", "Horvát juhászkutya" },
                    { 35, "[\"Black\"]", "Small", "Schipperke" },
                    { 36, "[\"Black\",\"Red\",\"Brown\"]", "Large", "Dobermann" },
                    { 37, "[\"Black\",\"Red\"]", "Medium", "Német pinscher" },
                    { 38, "[\"Black\",\"Red\"]", "Small", "Törpe pinscher" },
                    { 39, "[\"Black\",\"Grey\"]", "Small", "Affenpinscher" },
                    { 40, "[\"Black\",\"Grey\"]", "Large", "Óriás schnauzer" },
                    { 41, "[\"Black\",\"Grey\"]", "Medium", "Középschnauzer" },
                    { 42, "[\"Black\",\"Grey\",\"White\"]", "Small", "Törpe schnauzer" },
                    { 43, "[\"Black\"]", "Large", "Orosz fekete terrier" },
                    { 44, "[\"Black\",\"Red\"]", "Large", "Rottweiler" },
                    { 45, "[\"Red\",\"Gold\",\"Brindle\",\"White\"]", "Large", "Német boxer" },
                    { 46, "[\"Black\",\"Gold\",\"Grey\",\"White\",\"Brindle\"]", "Large", "Német dog" },
                    { 47, "[\"Black\",\"Brown\",\"White\"]", "Large", "Újfundlandi" },
                    { 48, "[\"White\",\"Black\"]", "Large", "Landseer" },
                    { 49, "[\"Red\",\"White\",\"Brown\"]", "Large", "Bernáthegyi" },
                    { 50, "[\"Gold\",\"Red\",\"Brown\",\"Black\"]", "Large", "Leonbergi" },
                    { 51, "[\"Black\",\"Gold\",\"Red\"]", "Large", "Hovawart" },
                    { 52, "[\"Black\",\"Red\",\"White\"]", "Large", "Berni pásztorkutya" },
                    { 53, "[\"Black\",\"Red\",\"White\"]", "Large", "Nagy svájci havasi kutya" },
                    { 54, "[\"Black\",\"Brown\",\"Red\",\"White\"]", "Medium", "Appenzelli havasi kutya" },
                    { 55, "[\"Black\",\"Red\",\"White\"]", "Medium", "Entlebuchi havasi kutya" },
                    { 56, "[\"Black\",\"Grey\",\"Gold\",\"Red\",\"Brindle\"]", "Large", "Cane Corso" },
                    { 57, "[\"Grey\",\"Black\",\"Brown\",\"Brindle\"]", "Large", "Nápolyi masztiff" },
                    { 58, "[\"Gold\",\"Grey\",\"Brindle\"]", "Large", "Angol masztiff" },
                    { 59, "[\"Red\",\"Gold\",\"Brindle\"]", "Large", "Bullmasztiff" },
                    { 60, "[\"Red\",\"Gold\"]", "Large", "Bordeaux-i dog" },
                    { 61, "[\"Gold\",\"Red\",\"Black\",\"Brindle\"]", "Large", "Spanyol masztiff" },
                    { 62, "[\"White\",\"Grey\",\"Gold\",\"Black\"]", "Large", "Pireneusi masztiff" },
                    { 63, "[\"White\",\"Grey\"]", "Large", "Pireneusi hegyikutya" },
                    { 64, "[\"Grey\",\"Gold\",\"White\",\"Red\",\"Brindle\"]", "Large", "Kaukázusi juhászkutya" },
                    { 65, "[\"White\",\"Black\",\"Grey\",\"Red\",\"Gold\",\"Brindle\"]", "Large", "Közép-ázsiai juhászkutya" },
                    { 66, "[\"White\",\"Grey\"]", "Large", "Délorosz juhászkutya" },
                    { 67, "[\"Black\",\"Gold\",\"Grey\",\"Red\"]", "Large", "Tibeti masztiff" },
                    { 68, "[\"Black\",\"Red\",\"Gold\",\"Grey\",\"Brown\"]", "Medium", "Shar pei" },
                    { 69, "[\"White\"]", "Large", "Dogo Argentino" },
                    { 70, "[\"Black\",\"Gold\",\"Brindle\"]", "Large", "Fila Brasileiro" },
                    { 71, "[\"Brown\",\"Gold\",\"Grey\",\"Brindle\"]", "Large", "Presa Canario" },
                    { 72, "[\"Red\",\"White\",\"Gold\",\"Brindle\"]", "Medium", "Angol bulldog" },
                    { 73, "[\"Grey\",\"Gold\",\"Black\"]", "Small", "Yorkshire terrier" },
                    { 74, "[\"White\",\"Black\",\"Brown\",\"Red\"]", "Small", "Jack Russell terrier" },
                    { 75, "[\"White\",\"Black\",\"Red\"]", "Small", "Parson Russell terrier" },
                    { 76, "[\"White\",\"Black\",\"Red\"]", "Small", "Foxterrier (sima szőrű)" },
                    { 77, "[\"White\",\"Black\",\"Red\"]", "Small", "Foxterrier (drótszőrű)" },
                    { 78, "[\"Black\",\"Red\"]", "Large", "Airedale terrier" },
                    { 79, "[\"Black\",\"Red\"]", "Small", "Welsh terrier" },
                    { 80, "[\"Red\",\"Gold\"]", "Medium", "Ír terrier" },
                    { 81, "[\"Grey\"]", "Medium", "Kerry blue terrier" },
                    { 82, "[\"Gold\"]", "Medium", "Soft-coated wheaten terrier" },
                    { 83, "[\"White\",\"Red\",\"Black\",\"Brindle\"]", "Medium", "Bullterrier" },
                    { 84, "[\"White\",\"Red\",\"Black\",\"Brindle\"]", "Small", "Miniatűr bullterrier" },
                    { 85, "[\"Red\",\"Gold\",\"White\",\"Black\",\"Grey\",\"Brindle\"]", "Medium", "Staffordshire bullterrier" },
                    { 86, "[\"Black\",\"White\",\"Red\",\"Grey\",\"Brindle\"]", "Medium", "Amerikai staffordshire terrier" },
                    { 87, "[\"Red\",\"Grey\",\"Gold\"]", "Small", "Border terrier" },
                    { 88, "[\"Grey\",\"Red\",\"Gold\",\"Brindle\"]", "Small", "Cairn terrier" },
                    { 89, "[\"Black\",\"Grey\",\"Gold\",\"Brindle\"]", "Small", "Skót terrier" },
                    { 90, "[\"White\"]", "Small", "Nyugat-felföldi fehér terrier (Westie)" },
                    { 91, "[\"Red\",\"Gold\",\"Black\",\"Grey\"]", "Small", "Norwich terrier" },
                    { 92, "[\"Red\",\"Gold\",\"Black\",\"Grey\"]", "Small", "Norfolk terrier" },
                    { 93, "[\"Grey\",\"Brown\",\"White\"]", "Medium", "Bedlington terrier" },
                    { 94, "[\"Black\",\"Red\"]", "Small", "Német vadászterrier (Jagdterrier)" },
                    { 95, "[\"Grey\",\"Brown\"]", "Small", "Cseh terrier" },
                    { 96, "[\"Grey\",\"Red\"]", "Small", "Ausztrál terrier" },
                    { 97, "[\"Black\",\"Red\",\"Brown\",\"Grey\",\"Brindle\"]", "Small", "Rövidszőrű standard tacskó" },
                    { 98, "[\"Grey\",\"Brown\",\"Black\",\"Red\"]", "Small", "Szálkásszőrű standard tacskó" },
                    { 99, "[\"Black\",\"Red\",\"Brown\"]", "Small", "Hosszúszőrű standard tacskó" },
                    { 100, "[\"Black\",\"Red\",\"Brown\",\"Grey\"]", "Small", "Rövidszőrű törpe tacskó" },
                    { 101, "[\"Grey\",\"Brown\",\"Black\",\"Red\"]", "Small", "Szálkásszőrű törpe tacskó" },
                    { 102, "[\"Black\",\"Red\",\"Brown\"]", "Small", "Hosszúszőrű törpe tacskó" },
                    { 103, "[\"Black\",\"Red\",\"Brown\"]", "Small", "Kaninchen tacskó" },
                    { 104, "[\"Black\",\"White\",\"Grey\",\"Red\"]", "Medium", "Szibériai husky" },
                    { 105, "[\"Grey\",\"Black\",\"Red\",\"White\"]", "Large", "Alaszkai malamut" },
                    { 106, "[\"White\"]", "Medium", "Szamojéd" },
                    { 107, "[\"Grey\",\"Black\",\"Brown\",\"White\"]", "Large", "Grönlandi kutya" },
                    { 108, "[\"Red\",\"Gold\",\"White\",\"Brindle\"]", "Large", "Akita inu" },
                    { 109, "[\"Black\",\"White\",\"Red\",\"Gold\",\"Brindle\"]", "Large", "Amerikai akita" },
                    { 110, "[\"Red\",\"Black\",\"Gold\",\"White\"]", "Small", "Shiba inu" },
                    { 111, "[\"White\",\"Red\",\"Black\",\"Grey\",\"Brindle\"]", "Medium", "Hokkaido" },
                    { 112, "[\"White\",\"Red\",\"Gold\"]", "Medium", "Kishu" },
                    { 113, "[\"Black\",\"Red\",\"Brindle\"]", "Medium", "Kai" },
                    { 114, "[\"Red\",\"Black\",\"Grey\",\"Gold\",\"White\"]", "Medium", "Csaucsau" },
                    { 115, "[\"Red\",\"Black\",\"Grey\",\"Gold\"]", "Medium", "Eurázsiai" },
                    { 116, "[\"Grey\",\"Black\"]", "Medium", "Keeshond (Farkasspicc)" },
                    { 117, "[\"White\",\"Black\",\"Brown\"]", "Medium", "Nagy spicc" },
                    { 118, "[\"White\",\"Black\",\"Brown\",\"Red\",\"Grey\"]", "Small", "Közép spicc" },
                    { 119, "[\"White\",\"Black\",\"Brown\",\"Red\",\"Grey\"]", "Small", "Kis spicc" },
                    { 120, "[\"White\",\"Black\",\"Brown\",\"Red\",\"Grey\",\"Gold\"]", "Small", "Pomerániai törpespicc" },
                    { 121, "[\"Grey\",\"Black\"]", "Medium", "Norvég elghund" },
                    { 122, "[\"Black\",\"White\"]", "Medium", "Karéliai medvekutya" },
                    { 123, "[\"Red\",\"Black\",\"White\",\"Brindle\"]", "Small", "Basenji" },
                    { 124, "[\"Red\",\"Gold\",\"White\"]", "Medium", "Fáraókutya" },
                    { 125, "[\"Red\",\"White\"]", "Large", "Podenco ibicenco" },
                    { 126, "[\"Gold\",\"Red\",\"Black\",\"White\"]", "Medium", "Podengo português" },
                    { 127, "[\"Black\",\"Grey\",\"Brown\",\"Red\"]", "Medium", "Mexikói meztelen kutya (Xoloitzcuintle)" },
                    { 128, "[\"Black\",\"Grey\",\"Brown\"]", "Medium", "Perui meztelen kutya" },
                    { 129, "[\"White\",\"Black\",\"Brown\",\"Red\"]", "Small", "Beagle" },
                    { 130, "[\"White\",\"Black\",\"Brown\",\"Red\"]", "Medium", "Basset hound" },
                    { 131, "[\"White\",\"Black\",\"Brown\"]", "Large", "Dalmata" },
                    { 132, "[\"Red\",\"Gold\"]", "Large", "Rhodéziai ridgeback" },
                    { 133, "[\"Black\",\"Red\",\"Gold\"]", "Large", "Angol véreb (Bloodhound)" },
                    { 134, "[\"Red\",\"Gold\",\"Brown\"]", "Medium", "Bajor hegyi véreb" },
                    { 135, "[\"Red\",\"Grey\",\"Brindle\"]", "Medium", "Hannoveri véreb" },
                    { 136, "[\"Black\",\"Red\"]", "Small", "Alpesi tacskókopó" },
                    { 137, "[\"White\",\"Black\",\"Red\"]", "Large", "Angol rókakopó (Foxhound)" },
                    { 138, "[\"White\",\"Black\",\"Red\"]", "Large", "Amerikai rókakopó" },
                    { 139, "[\"Black\",\"Red\"]", "Large", "Fekete-cser mosómedvekopó" },
                    { 140, "[\"White\",\"Gold\"]", "Medium", "Isztriai rövidszőrű kopó" },
                    { 141, "[\"White\",\"Black\",\"Red\"]", "Medium", "Svájci kopó" },
                    { 142, "[\"White\",\"Black\",\"Red\"]", "Medium", "Nyulászkopó (Harrier)" },
                    { 143, "[\"White\",\"Black\",\"Grey\",\"Gold\"]", "Medium", "Grand Basset Griffon Vendéen" },
                    { 144, "[\"White\",\"Black\",\"Grey\",\"Gold\"]", "Small", "Petit Basset Griffon Vendéen" },
                    { 145, "[\"Brown\",\"White\",\"Black\"]", "Large", "Rövidszőrű német vizsla" },
                    { 146, "[\"Brown\",\"White\",\"Black\"]", "Large", "Drótszőrű német vizsla" },
                    { 147, "[\"Brown\",\"White\"]", "Large", "Hosszúszőrű német vizsla" },
                    { 148, "[\"Grey\"]", "Large", "Weimari vizsla" },
                    { 149, "[\"White\",\"Black\",\"Gold\",\"Brown\",\"Red\"]", "Large", "Angol pointer" },
                    { 150, "[\"White\",\"Black\",\"Gold\",\"Brown\"]", "Large", "Angol szetter" },
                    { 151, "[\"Red\"]", "Large", "Ír vörös szetter" },
                    { 152, "[\"White\",\"Red\"]", "Large", "Ír vörös-fehér szetter" },
                    { 153, "[\"Black\",\"Red\"]", "Large", "Gordon szetter" },
                    { 154, "[\"White\",\"Gold\",\"Brown\"]", "Large", "Olasz vizsla (Bracco Italiano)" },
                    { 155, "[\"White\",\"Gold\",\"Brown\"]", "Large", "Spinone Italiano" },
                    { 156, "[\"Brown\",\"White\"]", "Medium", "Francia vizsla (Braque Français)" },
                    { 157, "[\"Brown\",\"White\"]", "Medium", "Münsterlandi kis vizsla" },
                    { 158, "[\"Black\",\"White\"]", "Large", "Münsterlandi nagy vizsla" },
                    { 159, "[\"Grey\",\"Black\"]", "Medium", "Kék picardiai spániel" },
                    { 160, "[\"White\",\"Brown\"]", "Medium", "Drenti vizsla" },
                    { 161, "[\"Brown\",\"Grey\",\"White\"]", "Large", "Cseh szálkásszőrű vizsla (Fousek)" },
                    { 162, "[\"Gold\",\"White\"]", "Large", "Golden retriever" },
                    { 163, "[\"Black\",\"Gold\",\"Brown\"]", "Large", "Labrador retriever" },
                    { 164, "[\"Black\",\"Brown\"]", "Large", "Flat-coated retriever" },
                    { 165, "[\"Brown\",\"Gold\"]", "Large", "Chesapeake Bay retriever" },
                    { 166, "[\"Black\",\"Brown\"]", "Large", "Göndörszőrű retriever (Curly-Coated)" },
                    { 167, "[\"Red\",\"Gold\",\"White\"]", "Medium", "Tolling retriever (Nova Scotia)" },
                    { 168, "[\"Black\",\"Gold\",\"Red\",\"Brown\",\"White\",\"Grey\"]", "Medium", "Angol cocker spániel" },
                    { 169, "[\"Black\",\"Gold\",\"Brown\",\"Red\",\"White\"]", "Small", "Amerikai cocker spániel" },
                    { 170, "[\"White\",\"Brown\",\"Black\"]", "Medium", "Angol springer spániel" },
                    { 171, "[\"White\",\"Red\"]", "Medium", "Welsh springer spániel" },
                    { 172, "[\"White\",\"Gold\"]", "Large", "Clumber spániel" },
                    { 173, "[\"Black\",\"Brown\",\"Grey\"]", "Medium", "Field spániel" },
                    { 174, "[\"Gold\",\"Brown\"]", "Medium", "Sussexi spániel" },
                    { 175, "[\"White\",\"Black\",\"Brown\"]", "Medium", "Spanyol vízikutya" },
                    { 176, "[\"Black\",\"White\",\"Brown\"]", "Medium", "Portugál vízikutya" },
                    { 177, "[\"White\",\"Brown\",\"Gold\"]", "Medium", "Olasz vízikutya (Lagotto Romagnolo)" },
                    { 178, "[\"Brown\"]", "Large", "Ír vízispániel" },
                    { 179, "[\"White\",\"Red\"]", "Small", "Kooikerhondje" },
                    { 180, "[\"Black\",\"White\",\"Red\",\"Gold\",\"Brown\",\"Grey\",\"Brindle\"]", "Small", "Csivava" },
                    { 181, "[\"Gold\",\"White\",\"Black\",\"Brindle\"]", "Small", "Francia bulldog" },
                    { 182, "[\"Gold\",\"Black\",\"Grey\"]", "Small", "Mopsz" },
                    { 183, "[\"Black\",\"White\",\"Brindle\"]", "Small", "Boston terrier" },
                    { 184, "[\"Black\",\"Red\",\"White\"]", "Small", "Cavalier King Charles spániel" },
                    { 185, "[\"Black\",\"Red\",\"White\"]", "Small", "King Charles spániel" },
                    { 186, "[\"Black\",\"White\",\"Brown\",\"Grey\",\"Gold\",\"Red\"]", "Large", "Óriásuszkár" },
                    { 187, "[\"Black\",\"White\",\"Brown\",\"Grey\",\"Gold\",\"Red\"]", "Medium", "Középuszkár" },
                    { 188, "[\"Black\",\"White\",\"Brown\",\"Grey\",\"Gold\",\"Red\"]", "Small", "Törpeuszkár" },
                    { 189, "[\"Black\",\"White\",\"Brown\",\"Grey\",\"Gold\",\"Red\"]", "Small", "Toy uszkár" },
                    { 190, "[\"White\"]", "Small", "Máltai selyemkutya" },
                    { 191, "[\"White\"]", "Small", "Bichon frisé" },
                    { 192, "[\"White\"]", "Small", "Bolognese" },
                    { 193, "[\"White\",\"Gold\",\"Black\",\"Brown\",\"Grey\"]", "Small", "Havanese" },
                    { 194, "[\"White\"]", "Small", "Coton de Tuléar" },
                    { 195, "[\"Black\",\"White\",\"Grey\",\"Gold\"]", "Small", "Kis oroszlánkutya (Löwchen)" },
                    { 196, "[\"Gold\",\"White\",\"Black\",\"Brown\",\"Grey\"]", "Small", "Shih-tzu" },
                    { 197, "[\"Gold\",\"Grey\",\"Black\",\"White\",\"Brown\"]", "Small", "Lhasa apso" },
                    { 198, "[\"White\",\"Gold\",\"Grey\",\"Black\",\"Brown\"]", "Medium", "Tibeti terrier" },
                    { 199, "[\"Gold\",\"Red\",\"White\",\"Black\"]", "Small", "Tibeti spániel" },
                    { 200, "[\"Gold\",\"Red\",\"Black\",\"White\",\"Grey\"]", "Small", "Pekingi palotakutya" },
                    { 201, "[\"White\",\"Black\",\"Red\"]", "Small", "Japán csin" },
                    { 202, "[\"White\",\"Black\",\"Grey\"]", "Small", "Kínai meztelen kutya" },
                    { 203, "[\"White\",\"Black\",\"Red\",\"Gold\"]", "Small", "Papillon (Lepkekutya)" },
                    { 204, "[\"White\",\"Black\",\"Red\",\"Gold\"]", "Small", "Phalène" },
                    { 205, "[\"Red\"]", "Small", "Brüsszeli griffon" },
                    { 206, "[\"Black\"]", "Small", "Belga griffon" },
                    { 207, "[\"Black\",\"Red\"]", "Small", "Kis brabanti griffon" },
                    { 208, "[\"Black\",\"White\",\"Red\",\"Grey\",\"Gold\",\"Brindle\"]", "Large", "Angol agár (Greyhound)" },
                    { 209, "[\"Gold\",\"Black\",\"White\",\"Grey\",\"Red\"]", "Large", "Afgán agár" },
                    { 210, "[\"White\",\"Gold\",\"Red\",\"Grey\",\"Black\"]", "Large", "Saluki (Perzsa agár)" },
                    { 211, "[\"White\",\"Gold\",\"Grey\",\"Red\",\"Black\",\"Brindle\"]", "Large", "Orosz agár (Barzoj)" },
                    { 212, "[\"Grey\",\"Brindle\",\"Red\",\"Black\",\"White\",\"Gold\"]", "Large", "Ír farkaskutya" },
                    { 213, "[\"Grey\",\"Brindle\"]", "Large", "Skót szarvasagár (Deerhound)" },
                    { 214, "[\"Black\",\"White\",\"Red\",\"Grey\",\"Gold\",\"Brindle\"]", "Medium", "Whippet" },
                    { 215, "[\"Black\",\"Grey\",\"Gold\"]", "Small", "Kis olasz agár" },
                    { 216, "[\"Black\",\"Gold\",\"Red\",\"White\",\"Brindle\"]", "Large", "Spanyol agár (Galgo Español)" },
                    { 217, "[\"Gold\",\"Grey\",\"Black\",\"White\"]", "Large", "Lengyel agár" },
                    { 218, "[\"Gold\",\"Grey\",\"Black\",\"Brindle\"]", "Large", "Sloughi (Arab agár)" },
                    { 219, "[\"Gold\",\"Red\",\"White\",\"Brindle\"]", "Large", "Azawakh" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BreedId",
                table: "Dogs",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_LastSeenAddressId",
                table: "Dogs",
                column: "LastSeenAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DogBreed_Name",
                table: "DogBreed",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Addresses_LastSeenAddressId",
                table: "Dogs",
                column: "LastSeenAddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_DogBreed_BreedId",
                table: "Dogs",
                column: "BreedId",
                principalTable: "DogBreed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Addresses_LastSeenAddressId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_DogBreed_BreedId",
                table: "Dogs");

            migrationBuilder.DropTable(
                name: "DogBreed");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_BreedId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_LastSeenAddressId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "BreedType",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "LastSeenAddressId",
                table: "Dogs");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Point>(
                name: "LastSeenLocation",
                table: "Dogs",
                type: "geography",
                nullable: false,
                oldClrType: typeof(Point),
                oldType: "geography",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Dogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Breed",
                table: "Dogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }
    }
}

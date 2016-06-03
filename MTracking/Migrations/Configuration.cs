namespace MTracking.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MTracking.Models.MContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MTracking.Models.MContext";
        }

        protected override void Seed(MTracking.Models.MContext context)
        {
            context.Countries.AddOrUpdate(i => i.Name,
                new dic_Countries { Name = "Afghanistan" },
                new dic_Countries { Name = "Albania" },
                new dic_Countries { Name = "Algeria" },
                new dic_Countries { Name = "Andorra" },
                new dic_Countries { Name = "Angola" },
                new dic_Countries { Name = "Antigua and Barbuda" },
                new dic_Countries { Name = "Argentina" },
                new dic_Countries { Name = "Armenia" },
                new dic_Countries { Name = "Aruba" },
                new dic_Countries { Name = "Australia" },
                new dic_Countries { Name = "Austria" },
                new dic_Countries { Name = "Azerbaijan" },
                new dic_Countries { Name = "Bahamas, The" },
                new dic_Countries { Name = "Bahrain" },
                new dic_Countries { Name = "Bangladesh" },
                new dic_Countries { Name = "Barbados" },
                new dic_Countries { Name = "Belarus" },
                new dic_Countries { Name = "Belgium" },
                new dic_Countries { Name = "Belize" },
                new dic_Countries { Name = "Benin" },
                new dic_Countries { Name = "Bhutan" },
                new dic_Countries { Name = "Bolivia" },
                new dic_Countries { Name = "Bosnia and Herzegovina" },
                new dic_Countries { Name = "Botswana" },
                new dic_Countries { Name = "Brazil" },
                new dic_Countries { Name = "Brunei" },
                new dic_Countries { Name = "Bulgaria" },
                new dic_Countries { Name = "Burkina Faso" },
                new dic_Countries { Name = "Burma" },
                new dic_Countries { Name = "Burundi" },
                new dic_Countries { Name = "Cambodia" },
                new dic_Countries { Name = "Cameroon" },
                new dic_Countries { Name = "Canada" },
                new dic_Countries { Name = "Cape Verde" },
                new dic_Countries { Name = "Central African Republic" },
                new dic_Countries { Name = "Chad" },
                new dic_Countries { Name = "Chile" },
                new dic_Countries { Name = "China" },
                new dic_Countries { Name = "Colombia" },
                new dic_Countries { Name = "Comoros" },
                new dic_Countries { Name = "Congo, Democratic Republic of the" },
                new dic_Countries { Name = "Congo, Republic of the" },
                new dic_Countries { Name = "Costa Rica" },
                new dic_Countries { Name = "Cote d'Ivoire" },
                new dic_Countries { Name = "Croatia" },
                new dic_Countries { Name = "Cuba" },
                new dic_Countries { Name = "Curacao" },
                new dic_Countries { Name = "Cyprus" },
                new dic_Countries { Name = "Czech Republic" },
                new dic_Countries { Name = "Denmark" },
                new dic_Countries { Name = "Djibouti" },
                new dic_Countries { Name = "Dominica" },
                new dic_Countries { Name = "Dominican Republic" },
                new dic_Countries { Name = "East Timor (see Timor-Leste)" },
                new dic_Countries { Name = "Ecuador" },
                new dic_Countries { Name = "Egypt" },
                new dic_Countries { Name = "El Salvador" },
                new dic_Countries { Name = "Equatorial Guinea" },
                new dic_Countries { Name = "Eritrea" },
                new dic_Countries { Name = "Estonia" },
                new dic_Countries { Name = "Ethiopia" },
                new dic_Countries { Name = "Fiji" },
                new dic_Countries { Name = "Finland" },
                new dic_Countries { Name = "France" },
                new dic_Countries { Name = "Gabon" },
                new dic_Countries { Name = "Gambia, The" },
                new dic_Countries { Name = "Georgia" },
                new dic_Countries { Name = "Germany" },
                new dic_Countries { Name = "Ghana" },
                new dic_Countries { Name = "Greece" },
                new dic_Countries { Name = "Grenada" },
                new dic_Countries { Name = "Guatemala" },
                new dic_Countries { Name = "Guinea" },
                new dic_Countries { Name = "Guinea-Bissau" },
                new dic_Countries { Name = "Guyana" },
                new dic_Countries { Name = "Haiti" },
                new dic_Countries { Name = "Holy See" },
                new dic_Countries { Name = "Honduras" },
                new dic_Countries { Name = "Hong Kong" },
                new dic_Countries { Name = "Hungary" },
                new dic_Countries { Name = "Iceland" },
                new dic_Countries { Name = "India" },
                new dic_Countries { Name = "Indonesia" },
                new dic_Countries { Name = "Iran" },
                new dic_Countries { Name = "Iraq" },
                new dic_Countries { Name = "Ireland" },
                new dic_Countries { Name = "Israel" },
                new dic_Countries { Name = "Italy" },
                new dic_Countries { Name = "Jamaica" },
                new dic_Countries { Name = "Japan" },
                new dic_Countries { Name = "Jordan" },
                new dic_Countries { Name = "Kazakhstan" },
                new dic_Countries { Name = "Kenya" },
                new dic_Countries { Name = "Kiribati" },
                new dic_Countries { Name = "Korea, North" },
                new dic_Countries { Name = "Korea, South" },
                new dic_Countries { Name = "Kosovo" },
                new dic_Countries { Name = "Kuwait" },
                new dic_Countries { Name = "Kyrgyzstan" },
                new dic_Countries { Name = "Laos" },
                new dic_Countries { Name = "Latvia" },
                new dic_Countries { Name = "Lebanon" },
                new dic_Countries { Name = "Lesotho" },
                new dic_Countries { Name = "Liberia" },
                new dic_Countries { Name = "Libya" },
                new dic_Countries { Name = "Liechtenstein" },
                new dic_Countries { Name = "Lithuania" },
                new dic_Countries { Name = "Luxembourg" },
                new dic_Countries { Name = "Macau" },
                new dic_Countries { Name = "Macedonia" },
                new dic_Countries { Name = "Madagascar" },
                new dic_Countries { Name = "Malawi" },
                new dic_Countries { Name = "Malaysia" },
                new dic_Countries { Name = "Maldives" },
                new dic_Countries { Name = "Mali" },
                new dic_Countries { Name = "Malta" },
                new dic_Countries { Name = "Marshall Islands" },
                new dic_Countries { Name = "Mauritania" },
                new dic_Countries { Name = "Mauritius" },
                new dic_Countries { Name = "Mexico" },
                new dic_Countries { Name = "Micronesia" },
                new dic_Countries { Name = "Moldova" },
                new dic_Countries { Name = "Monaco" },
                new dic_Countries { Name = "Mongolia" },
                new dic_Countries { Name = "Montenegro" },
                new dic_Countries { Name = "Morocco" },
                new dic_Countries { Name = "Mozambique" },
                new dic_Countries { Name = "Namibia" },
                new dic_Countries { Name = "Nauru" },
                new dic_Countries { Name = "Nepal" },
                new dic_Countries { Name = "Netherlands" },
                new dic_Countries { Name = "Netherlands Antilles" },
                new dic_Countries { Name = "New Zealand" },
                new dic_Countries { Name = "Nicaragua" },
                new dic_Countries { Name = "Niger" },
                new dic_Countries { Name = "Nigeria" },
                new dic_Countries { Name = "North Korea" },
                new dic_Countries { Name = "Norway" },
                new dic_Countries { Name = "Oman" },
                new dic_Countries { Name = "Pakistan" },
                new dic_Countries { Name = "Palau" },
                new dic_Countries { Name = "Palestinian Territories" },
                new dic_Countries { Name = "Panama" },
                new dic_Countries { Name = "Papua New Guinea" },
                new dic_Countries { Name = "Paraguay" },
                new dic_Countries { Name = "Peru" },
                new dic_Countries { Name = "Philippines" },
                new dic_Countries { Name = "Poland" },
                new dic_Countries { Name = "Portugal" },
                new dic_Countries { Name = "Qatar" },
                new dic_Countries { Name = "Romania" },
                new dic_Countries { Name = "Russia" },
                new dic_Countries { Name = "Rwanda" },
                new dic_Countries { Name = "Saint Kitts and Nevis" },
                new dic_Countries { Name = "Saint Lucia" },
                new dic_Countries { Name = "Saint Vincent and the Grenadines" },
                new dic_Countries { Name = "Samoa" },
                new dic_Countries { Name = "San Marino" },
                new dic_Countries { Name = "Sao Tome and Principe" },
                new dic_Countries { Name = "Saudi Arabia" },
                new dic_Countries { Name = "Senegal" },
                new dic_Countries { Name = "Serbia" },
                new dic_Countries { Name = "Seychelles" },
                new dic_Countries { Name = "Sierra Leone" },
                new dic_Countries { Name = "Singapore" },
                new dic_Countries { Name = "Sint Maarten" },
                new dic_Countries { Name = "Slovakia" },
                new dic_Countries { Name = "Slovenia" },
                new dic_Countries { Name = "Solomon Islands" },
                new dic_Countries { Name = "Somalia" },
                new dic_Countries { Name = "South Africa" },
                new dic_Countries { Name = "South Korea" },
                new dic_Countries { Name = "South Sudan" },
                new dic_Countries { Name = "Spain" },
                new dic_Countries { Name = "Sri Lanka" },
                new dic_Countries { Name = "Sudan" },
                new dic_Countries { Name = "Suriname" },
                new dic_Countries { Name = "Swaziland" },
                new dic_Countries { Name = "Sweden" },
                new dic_Countries { Name = "Switzerland" },
                new dic_Countries { Name = "Syria" },
                new dic_Countries { Name = "Taiwan" },
                new dic_Countries { Name = "Tajikistan" },
                new dic_Countries { Name = "Tanzania" },
                new dic_Countries { Name = "Thailand" },
                new dic_Countries { Name = "Timor-Leste" },
                new dic_Countries { Name = "Togo" },
                new dic_Countries { Name = "Tonga" },
                new dic_Countries { Name = "Trinidad and Tobago" },
                new dic_Countries { Name = "Tunisia" },
                new dic_Countries { Name = "Turkey" },
                new dic_Countries { Name = "Turkmenistan" },
                new dic_Countries { Name = "Tuvalu" },
                new dic_Countries { Name = "Uganda" },
                new dic_Countries { Name = "Ukraine" },
                new dic_Countries { Name = "United Arab Emirates" },
                new dic_Countries { Name = "United Kingdom" },
                new dic_Countries { Name = "Uruguay" },
                new dic_Countries { Name = "Uzbekistan" },
                new dic_Countries { Name = "Vanuatu" },
                new dic_Countries { Name = "Venezuela" },
                new dic_Countries { Name = "Vietnam" },
                new dic_Countries { Name = "Yemen" },
                new dic_Countries { Name = "Zambia" },
                new dic_Countries { Name = "Zimbabwe" }
            );

            context.Statuses.AddOrUpdate(i => i.Status,
                new dic_Statuses() { Status = "Developer" },
                new dic_Statuses() { Status = "Tester" },
                new dic_Statuses() { Status = "PM" }
            );

            context.Companies.AddOrUpdate(i => i.Name,
                new Company() { Name = "None" },
                new Company() { Name = "ITomich" },
                new Company() { Name = "Antarasoft" },
                new Company { Name = "SoftServe" },
                new Company { Name = "Eleks" },
                new Company { Name = "Miratech" },
                new Company { Name = "Sigma Software" },
                new Company { Name = "EPAM" },
                new Company { Name = "Luxoft" },
                new Company { Name = "Ciklum" },
                new Company { Name = "Intetics" },
                new Company { Name = "TEAM International Services" },
                new Company { Name = "Softjourn" }
            );

            context.BugStatuses.AddOrUpdate(i => i.Status,
                            new dic_BugStatuses() { Status = "New" },
                            new dic_BugStatuses() { Status = "Active" },
                            new dic_BugStatuses() { Status = "Resolved" },
                            new dic_BugStatuses() { Status = "Closed" }
                        );
        }
    }
}

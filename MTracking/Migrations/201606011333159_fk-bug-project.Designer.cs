// <auto-generated />
namespace MTracking.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class fkbugproject : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(fkbugproject));
        
        string IMigrationMetadata.Id
        {
            get { return "201606011333159_fk-bug-project"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }

    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class CopyOffkbugproject : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(CopyOffkbugproject));

        string IMigrationMetadata.Id
        {
            get { return "201606011333159_fk-bug-project"; }
        }

        string IMigrationMetadata.Source
        {
            get { return null; }
        }

        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}

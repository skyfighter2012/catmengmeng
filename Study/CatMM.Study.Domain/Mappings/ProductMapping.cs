using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace CatMM.Study.Domain.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductMapping : ClassMap<Product>
    {
        public ProductMapping()
        {
            Id(p => p.Id).GeneratedBy.GuidComb();

            DiscriminateSubClassesOnColumn("ProductType");

            Version(p => p.Version);

            NaturalId()
                .Not.ReadOnly() //This is the same as setting mutable = "true" in the XML mapping
                  .Property(p => p.Name);

            Map(p => p.Description);

            Map(p => p.UnitPrice).Not.Nullable();
        }
    }

    public class BookMapping : SubclassMap<Book>
    {
        public BookMapping()
        {
            Map(p => p.Author);
            Map(p => p.ISBN);
        }
    }

    public class MovieMapping : SubclassMap<Movie>
    {
        public MovieMapping()
        {
            Map(p => p.Director);
            HasMany(m => m.Actors)
                .KeyColumn("MovieId")
                .AsList(l => l.Column("ActorIndex"));
        }
    }

    public class ActorRoleMapping : ClassMap<ActorRole>
    {
        public ActorRoleMapping()
        {
            Id(p => p.Id).GeneratedBy.GuidComb();

            Version(it => it.Version);
            Map(it => it.Actor).Not.Nullable();
            Map(it => it.Role).Not.Nullable();
        }
    }
}

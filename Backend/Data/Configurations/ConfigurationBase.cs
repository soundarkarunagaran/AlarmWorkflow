﻿// This file is part of AlarmWorkflow.
// 
// AlarmWorkflow is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AlarmWorkflow is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with AlarmWorkflow.  If not, see <http://www.gnu.org/licenses/>.

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlarmWorkflow.Backend.Data.Types;

namespace AlarmWorkflow.Backend.Data.Configurations
{
    /// <summary>
    /// Abstract base class for a entity type configuration.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    abstract class ConfigurationBase<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationBase{TEntity}"/> class.
        /// </summary>
        protected ConfigurationBase()
            : base()
        {
            ToTable(GetTableName());

            MapKeys();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs automatic mapping of the <see cref="EntityBase.Id"/> key.
        /// </summary>
        protected virtual void MapKeys()
        {
            HasKey(e => e.Id);
            Property(e => e.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        /// <summary>
        /// When overridden in a derived class, customizes the table name for the provided <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>A string representing the table name. The default is the type name of the <typeparamref name="TEntity"/>.</returns>
        protected virtual string GetTableName()
        {
            return typeof(TEntity).Name;
        }

        #endregion
    }
}

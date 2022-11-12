using PetaPoco;
using SevenWinBackend.Application.Repositories;
using SevenWinBackend.Data.Base;
using SevenWinBackend.Domain.Common;
using SevenWinBackend.Domain.Entities;
using SevenWinBackend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWinBackend.Data.Repositories
{
    internal class ConfigRepository : BaseRepository<Config>, IConfigRepository
    {
        public ConfigRepository(IDatabase db) : base(db)
        {
        }

        public async Task<Config?> GetByName(ConfigKeyNames keyName)
        {
            if (keyName == ConfigKeyNames.None)
            {
                throw new ArgumentNullException(nameof(keyName));
            }
            return await this.Db.SingleOrDefaultAsync<Config?>("select * from config where key_name=@KeyName;", new { KeyName = keyName });
        }

        public async Task<string> GetAppId()
        {
            string sql = "select * from config where key_name = @AppId;";
            Config? config = await this.Db.SingleOrDefaultAsync<Config?>(sql, new { AppId = ConfigKeyNames.AppId });
            if (config == null)
            {
                throw new Exception("数据库中不存在应用标识");
            }
            else
            {
                return config.KeyValue;
            }
        }

        public async Task<Version> GetDbVersion()
        {
            string sql = "select * from config where key_name = @DbVersion;";
            Config? config = await this.Db.SingleOrDefaultAsync<Config?>(sql, new { DbVersion = ConfigKeyNames.DbVersion });
            if (config == null)
            {
                throw new Exception("数据库中不存在版本号");
            }
            else
            {
                return Version.Parse(config.KeyValue);
            }
        }

        public async Task SetAppId()
        {
            Config? config = await GetByName(ConfigKeyNames.AppId);
            if (config == null)
            {
                config = Config.Create(ConfigKeyNames.AppId, Constants.AppId);
                await this.Insert(config);
            }
            else
            {
                config.KeyValue = Constants.AppId;
                await this.Update(config);
            }
        }

        public async Task SetDbVersion(Version version)
        {
            if (version == null)
            {
                throw new ArgumentNullException(nameof(version));
            }
            Config? config = await GetByName(ConfigKeyNames.DbVersion);
            if (config == null)
            {
                config = Config.Create(ConfigKeyNames.DbVersion, version.ToString());
                await this.Insert(config);
            }
            else
            {
                config.KeyValue = version.ToString();
                await this.Update(config);
            }
        }
    }
}

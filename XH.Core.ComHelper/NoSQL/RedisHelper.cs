using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using XH.Core.ComHelper.ComHelper;

namespace XH.Core.ComHelper.NoSQLHelper
{
    public class RedisHelper
    {
        //单例模式
        public static RedisCommon Default => new RedisCommon();
        public static RedisCommon One => new RedisCommon(1, AppSetingHelper.APPSett.ReadWriteHosts);
        public static RedisCommon Two => new RedisCommon(2, AppSetingHelper.APPSett.ReadWriteHosts);
    
         
        /// <summary>
        /// Redis操作类
        /// 老版用的是ServiceStack.Redis。
        /// Net Core使用StackExchange.Redis的nuget包
        /// </summary>
        public class RedisCommon
        {                                                       //redis数据库连接字符串
            private readonly string _conn = AppSetingHelper.APPSett.ReadWriteHosts ?? "127.0.0.1:6379";
            private readonly int _db = 0;
            //静态变量 保证各模块使用的是不同实例的相同链接
            private static ConnectionMultiplexer connection;
            public RedisCommon() { }
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="db"></param>
            /// <param name="connectStr"></param>
            public RedisCommon(int db, string connectStr)
            {
                _conn = connectStr;
                _db = db;
            }
            /// <summary>
            /// 缓存数据库，数据库连接
            /// </summary>
            public ConnectionMultiplexer CacheConnection
            {
                get
                {
                    try
                    {
                        if (connection == null || !connection.IsConnected)
                        {
                            connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_conn)).Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLogFile("RedisHelper-CacheConnection", ex);
                        return null;
                    }
                    return connection;
                }
            }
            
            /// <summary>
            /// 缓存数据库
            /// </summary>
            public IDatabase CacheRedis => CacheConnection.GetDatabase(_db);

            #region string 
            /// <summary>
            /// 单条存值
            /// </summary>
            /// <param name="key">key</param>
            /// <param name="value">The value.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public bool StringSet(string key, string value)
            {
                return CacheRedis.StringSet(key, value);
            }
            /// <summary>
            /// 保存单个key value
            /// </summary>
            /// <param name="key">Redis Key</param>
            /// <param name="value">保存的值</param>
            /// <param name="expiry">过期时间</param>
            /// <returns></returns>
            public bool StringSet(string key, string value, TimeSpan? expiry = default(TimeSpan?))
            {

                string str = _conn;
                return CacheRedis.StringSet(key, value, expiry);
            }

            /// <summary>
            /// 保存多个key value
            /// </summary>
            /// <param name="arr">key</param>
            /// <returns></returns>
            public bool StringSet(KeyValuePair<RedisKey, RedisValue>[] arr)
            {
                return CacheRedis.StringSet(arr);
            }

            /// <summary>
            /// 批量存值
            /// </summary>
            /// <param name="keysStr">key</param>
            /// <param name="valuesStr">The value.</param>
            /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
            public bool StringSetMany(string[] keysStr, string[] valuesStr)
            {
                int count = keysStr.Length;
                KeyValuePair<RedisKey, RedisValue>[] keyValuePair = new KeyValuePair<RedisKey, RedisValue>[count];
                for (int i = 0; i < count; i++)
                {
                    keyValuePair[i] = new KeyValuePair<RedisKey, RedisValue>(keysStr[i], valuesStr[i]);
                }

                return CacheRedis.StringSet(keyValuePair);
            }
            /// <summary>
            /// 保存一个对象
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <param name="obj"></param>
            /// <returns></returns>
            public bool SetStringKey<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?))
            {
                string json = JsonConvert.SerializeObject(obj);
                return CacheRedis.StringSet(key, json, expiry);
            }

            /// <summary>
            /// 追加值
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void StringAppend(string key, string value)
            {
                ////追加值，返回追加后长度
                long appendlong = CacheRedis.StringAppend(key, value);
            }

            /// <summary>
            /// 获取单个key的值
            /// </summary>
            /// <param name="key">Redis Key</param>
            /// <returns></returns>
            public RedisValue GetStringKey(string key)
            {
                return CacheRedis.StringGet(key);
            }
            /// <summary>
            /// 根据Key获取值
            /// </summary>
            /// <param name="key">键值</param>
            /// <returns>System.String.</returns>
            public string StringGet(string key)
            {
                try
                {
                    return CacheRedis.StringGet(key);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLogFile("RedisHelper-StringGet", ex);
                    return null;
                }
            }
            /// <summary>
            /// 获取一个key的对象
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            public T GetStringKey<T>(string key)
            {
                return JsonConvert.DeserializeObject<T>(CacheRedis.StringGet(key));
            }
            /// <summary>
            /// 获取多个Key
            /// </summary>
            /// <param name="listKey">Redis Key集合</param>
            /// <returns></returns>
            public RedisValue[] GetStringKey(List<RedisKey> listKey)
            {
                return CacheRedis.StringGet(listKey.ToArray());
            }
            /// <summary>
            /// 批量获取值
            /// </summary>
            public string[] StringGetMany(string[] keyStrs)
            {
                int count = keyStrs.Length;
                RedisKey[] keys = new RedisKey[count];
                string[] addrs = new string[count];

                for (int i = 0; i < count; i++)
                {
                    keys[i] = keyStrs[i];
                }
                try
                {

                    RedisValue[] values = CacheRedis.StringGet(keys);
                    for (int i = 0; i < values.Length; i++)
                    {
                        addrs[i] = values[i];
                    }
                    return addrs;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLogFile("RedisHelper-StringGetMany", ex);
                    return null;
                }
            }
            /// <summary>
            /// 删除单个key
            /// </summary>
            /// <param name="key">redis key</param>
            /// <returns>是否删除成功</returns>
            public bool KeyDelete(string key)
            {
                return CacheRedis.KeyDelete(key);
            }
            /// <summary>
            /// 删除多个key
            /// </summary>
            /// <param name="keys">rediskey</param>
            /// <returns>成功删除的个数</returns>
            public long KeyDelete(RedisKey[] keys)
            {
                return CacheRedis.KeyDelete(keys);
            }
            /// <summary>
            /// 判断key是否存储
            /// </summary>
            /// <param name="key">redis key</param>
            /// <returns></returns>
            public bool KeyExists(string key)
            {
                return CacheRedis.KeyExists(key);
            }
            /// <summary>
            /// 重新命名key
            /// </summary>
            /// <param name="key">就的redis key</param>
            /// <param name="newKey">新的redis key</param>
            /// <returns></returns>
            public bool KeyRename(string key, string newKey)
            {
                return CacheRedis.KeyRename(key, newKey);
            }
            #endregion


            #region hash
            /// <summary>
            /// hash添加数据
            /// </summary>
            /// <param name="key"></param>
            /// <param name="dataKey"></param>
            /// <param name="t"></param>
            /// <returns></returns>
            public bool HashSet(string key, string dataKey, string str)
            {
                return CacheRedis.HashSet(key, dataKey, str);
            }
            /// <summary>
            /// 获取hash 数据
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <param name="hasFildValue"></param>
            /// <returns></returns>
            public T GetHashKey<T>(string key, string hasFildValue)
            {
                if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(hasFildValue))
                {
                    RedisValue value = CacheRedis.HashGet(key, hasFildValue);
                    if (!value.IsNullOrEmpty)
                    {
                        return (T)JsonConvert.DeserializeObject(value);
                    }
                }
                return default(T);
            }

            /// <summary>
            /// 删除hasekey
            /// </summary>
            /// <param name="key"></param>
            /// <param name="hashField"></param>
            /// <returns></returns>
            public bool HaseDelete(RedisKey key, RedisValue hashField)
            {
                return CacheRedis.HashDelete(key, hashField);
            }

            /// <summary>
            /// 判断hash 是否存在
            /// </summary>
            /// <param name="key"></param>
            /// <param name="dataKey"></param>
            /// <returns></returns>
            public bool HashExists(string key, string dataKey)
            {
                return CacheRedis.HashExists(key, dataKey);
            }
            /// <summary>
            /// 移除hash中的某值
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="key"></param>
            /// <param name="dataKey"></param>
            /// <returns></returns>
            public bool HashRemove(string key, string dataKey)
            {
                return CacheRedis.HashDelete(key, dataKey);
            }
            #endregion
            

            #region 通用
            /// <summary>
            /// 设置缓存过期
            /// </summary>
            /// <param name="key"></param>
            /// <param name="datetime"></param>
            public void SetExpire(string key, DateTime datetime)
            {
                CacheRedis.KeyExpire(key, datetime);
            }
            #endregion

        }

    }
}

﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NguyenThanhDat.Web06.Application;

namespace NguyenThanhDat.Web06.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbConnection? _connection = null;
        private DbTransaction? _transaction = null;
        private readonly string _connectionString;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Nếu chưa có connect thì khởi tạo một connectionString mới
        /// </summary>
        public DbConnection Connection => _connection ??= new MySqlConnection(_connectionString);

        /// <summary>
        /// Nếu transaction không tồn tại thì truyền null
        /// </summary>
        public DbTransaction? Transaction => _transaction;

        public void BeginTransaction()
        {
            _connection ??= new MySqlConnection(_connectionString);

            if (_connection.State == ConnectionState.Open)
            {
                _transaction = _connection.BeginTransaction();
            }
            else
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }
        }

        public async Task BeginTransactionAsync()
        {
            _connection ??= new MySqlConnection(_connectionString);
            // Nếu như trạng thái connection đang mở thì gọi transation
            if (_connection.State == ConnectionState.Open)
            {
                _transaction = await _connection.BeginTransactionAsync();
            }
            else
            {
                await _connection.OpenAsync();
                _transaction = await _connection.BeginTransactionAsync();
            }
        }

        public void Commit()
        {
            _transaction?.Commit();
            Dispose();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
            await DisposeAsync();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }

            if (_connection != null)
            {
                await _connection.DisposeAsync();
                _connection = null;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
            await DisposeAsync();
        }
    }
}

﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SERVPL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertZAST(ZAST instance);
    partial void UpdateZAST(ZAST instance);
    partial void DeleteZAST(ZAST instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::SERVPL.Properties.Settings.Default.Database1ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ZAST> ZASTs
		{
			get
			{
				return this.GetTable<ZAST>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.AddNewZast")]
		public int AddNewZast([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(20)")] string fName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(20)")] string lName, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(20)")] string carNum, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(20)")] string carBrand, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(20)")] string carModel, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> carType, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(10)")] string carAddinfo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> expireDateDay, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> expireDateMonth, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> expireDateYear, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> eemployee, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(20)")] string price, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="SmallInt")] System.Nullable<short> city)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fName, lName, carNum, carBrand, carModel, carType, carAddinfo, expireDateDay, expireDateMonth, expireDateYear, eemployee, price, city);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ZAST")]
	public partial class ZAST : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FName;
		
		private string _LName;
		
		private string _CarNum;
		
		private string _CarBrand;
		
		private string _CarModel;
		
		private short _CarType;
		
		private string _CarAddinfo;
		
		private short _ExpireDateDay;
		
		private short _ExpireDateMonth;
		
		private int _ExpireDateYear;
		
		private int _employee;
		
		private string _Price;
		
		private short _City;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFNameChanging(string value);
    partial void OnFNameChanged();
    partial void OnLNameChanging(string value);
    partial void OnLNameChanged();
    partial void OnCarNumChanging(string value);
    partial void OnCarNumChanged();
    partial void OnCarBrandChanging(string value);
    partial void OnCarBrandChanged();
    partial void OnCarModelChanging(string value);
    partial void OnCarModelChanged();
    partial void OnCarTypeChanging(short value);
    partial void OnCarTypeChanged();
    partial void OnCarAddinfoChanging(string value);
    partial void OnCarAddinfoChanged();
    partial void OnExpireDateDayChanging(short value);
    partial void OnExpireDateDayChanged();
    partial void OnExpireDateMonthChanging(short value);
    partial void OnExpireDateMonthChanged();
    partial void OnExpireDateYearChanging(int value);
    partial void OnExpireDateYearChanged();
    partial void OnemployeeChanging(int value);
    partial void OnemployeeChanged();
    partial void OnPriceChanging(string value);
    partial void OnPriceChanged();
    partial void OnCityChanging(short value);
    partial void OnCityChanged();
    #endregion
		
		public ZAST()
		{
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FName", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string FName
		{
			get
			{
				return this._FName;
			}
			set
			{
				if ((this._FName != value))
				{
					this.OnFNameChanging(value);
					this.SendPropertyChanging();
					this._FName = value;
					this.SendPropertyChanged("FName");
					this.OnFNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LName", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string LName
		{
			get
			{
				return this._LName;
			}
			set
			{
				if ((this._LName != value))
				{
					this.OnLNameChanging(value);
					this.SendPropertyChanging();
					this._LName = value;
					this.SendPropertyChanged("LName");
					this.OnLNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarNum", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string CarNum
		{
			get
			{
				return this._CarNum;
			}
			set
			{
				if ((this._CarNum != value))
				{
					this.OnCarNumChanging(value);
					this.SendPropertyChanging();
					this._CarNum = value;
					this.SendPropertyChanged("CarNum");
					this.OnCarNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarBrand", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string CarBrand
		{
			get
			{
				return this._CarBrand;
			}
			set
			{
				if ((this._CarBrand != value))
				{
					this.OnCarBrandChanging(value);
					this.SendPropertyChanging();
					this._CarBrand = value;
					this.SendPropertyChanged("CarBrand");
					this.OnCarBrandChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarModel", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string CarModel
		{
			get
			{
				return this._CarModel;
			}
			set
			{
				if ((this._CarModel != value))
				{
					this.OnCarModelChanging(value);
					this.SendPropertyChanging();
					this._CarModel = value;
					this.SendPropertyChanged("CarModel");
					this.OnCarModelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarType", DbType="SmallInt NOT NULL")]
		public short CarType
		{
			get
			{
				return this._CarType;
			}
			set
			{
				if ((this._CarType != value))
				{
					this.OnCarTypeChanging(value);
					this.SendPropertyChanging();
					this._CarType = value;
					this.SendPropertyChanged("CarType");
					this.OnCarTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CarAddinfo", DbType="NChar(10)")]
		public string CarAddinfo
		{
			get
			{
				return this._CarAddinfo;
			}
			set
			{
				if ((this._CarAddinfo != value))
				{
					this.OnCarAddinfoChanging(value);
					this.SendPropertyChanging();
					this._CarAddinfo = value;
					this.SendPropertyChanged("CarAddinfo");
					this.OnCarAddinfoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExpireDateDay", DbType="SmallInt NOT NULL")]
		public short ExpireDateDay
		{
			get
			{
				return this._ExpireDateDay;
			}
			set
			{
				if ((this._ExpireDateDay != value))
				{
					this.OnExpireDateDayChanging(value);
					this.SendPropertyChanging();
					this._ExpireDateDay = value;
					this.SendPropertyChanged("ExpireDateDay");
					this.OnExpireDateDayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExpireDateMonth", DbType="SmallInt NOT NULL")]
		public short ExpireDateMonth
		{
			get
			{
				return this._ExpireDateMonth;
			}
			set
			{
				if ((this._ExpireDateMonth != value))
				{
					this.OnExpireDateMonthChanging(value);
					this.SendPropertyChanging();
					this._ExpireDateMonth = value;
					this.SendPropertyChanged("ExpireDateMonth");
					this.OnExpireDateMonthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExpireDateYear", DbType="Int NOT NULL")]
		public int ExpireDateYear
		{
			get
			{
				return this._ExpireDateYear;
			}
			set
			{
				if ((this._ExpireDateYear != value))
				{
					this.OnExpireDateYearChanging(value);
					this.SendPropertyChanging();
					this._ExpireDateYear = value;
					this.SendPropertyChanged("ExpireDateYear");
					this.OnExpireDateYearChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_employee", DbType="Int NOT NULL")]
		public int employee
		{
			get
			{
				return this._employee;
			}
			set
			{
				if ((this._employee != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnemployeeChanging(value);
					this.SendPropertyChanging();
					this._employee = value;
					this.SendPropertyChanged("employee");
					this.OnemployeeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_City", DbType="SmallInt NOT NULL")]
		public short City
		{
			get
			{
				return this._City;
			}
			set
			{
				if ((this._City != value))
				{
					this.OnCityChanging(value);
					this.SendPropertyChanging();
					this._City = value;
					this.SendPropertyChanged("City");
					this.OnCityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ZAST", Storage="_User", ThisKey="employee", OtherKey="Id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.ZASTs.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.ZASTs.Add(this);
						this._employee = value.Id;
					}
					else
					{
						this._employee = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _FName;
		
		private string _LName;
		
		private string _Username;
		
		private string _Pass;
		
		private string _Email;
		
		private EntitySet<ZAST> _ZASTs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFNameChanging(string value);
    partial void OnFNameChanged();
    partial void OnLNameChanging(string value);
    partial void OnLNameChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPassChanging(string value);
    partial void OnPassChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public User()
		{
			this._ZASTs = new EntitySet<ZAST>(new Action<ZAST>(this.attach_ZASTs), new Action<ZAST>(this.detach_ZASTs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FName", DbType="NChar(20)")]
		public string FName
		{
			get
			{
				return this._FName;
			}
			set
			{
				if ((this._FName != value))
				{
					this.OnFNameChanging(value);
					this.SendPropertyChanging();
					this._FName = value;
					this.SendPropertyChanged("FName");
					this.OnFNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LName", DbType="NChar(20)")]
		public string LName
		{
			get
			{
				return this._LName;
			}
			set
			{
				if ((this._LName != value))
				{
					this.OnLNameChanging(value);
					this.SendPropertyChanging();
					this._LName = value;
					this.SendPropertyChanged("LName");
					this.OnLNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pass", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string Pass
		{
			get
			{
				return this._Pass;
			}
			set
			{
				if ((this._Pass != value))
				{
					this.OnPassChanging(value);
					this.SendPropertyChanging();
					this._Pass = value;
					this.SendPropertyChanged("Pass");
					this.OnPassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ZAST", Storage="_ZASTs", ThisKey="Id", OtherKey="employee")]
		public EntitySet<ZAST> ZASTs
		{
			get
			{
				return this._ZASTs;
			}
			set
			{
				this._ZASTs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_ZASTs(ZAST entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_ZASTs(ZAST entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
}
#pragma warning restore 1591

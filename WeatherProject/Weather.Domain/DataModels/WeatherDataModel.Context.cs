﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Weather.Domain.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WeatherDataEntities : DbContext
    {
        public WeatherDataEntities()
            : base("name=WeatherDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<WeatherByDay> WeatherByDay { get; set; }
    
        public virtual int usp_City_Delete(Nullable<int> cityID)
        {
            var cityIDParameter = cityID.HasValue ?
                new ObjectParameter("CityID", cityID) :
                new ObjectParameter("CityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_City_Delete", cityIDParameter);
        }
    
        public virtual int usp_City_GetById(Nullable<int> cityID)
        {
            var cityIDParameter = cityID.HasValue ?
                new ObjectParameter("CityID", cityID) :
                new ObjectParameter("CityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_City_GetById", cityIDParameter);
        }
    
        public virtual int usp_City_Insert(string name, Nullable<double> lat, Nullable<double> lon)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var latParameter = lat.HasValue ?
                new ObjectParameter("Lat", lat) :
                new ObjectParameter("Lat", typeof(double));
    
            var lonParameter = lon.HasValue ?
                new ObjectParameter("Lon", lon) :
                new ObjectParameter("Lon", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_City_Insert", nameParameter, latParameter, lonParameter);
        }
    
        public virtual int usp_City_Update(Nullable<int> cityID, string name, Nullable<double> lat, Nullable<double> lon)
        {
            var cityIDParameter = cityID.HasValue ?
                new ObjectParameter("CityID", cityID) :
                new ObjectParameter("CityID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var latParameter = lat.HasValue ?
                new ObjectParameter("Lat", lat) :
                new ObjectParameter("Lat", typeof(double));
    
            var lonParameter = lon.HasValue ?
                new ObjectParameter("Lon", lon) :
                new ObjectParameter("Lon", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_City_Update", cityIDParameter, nameParameter, latParameter, lonParameter);
        }
    
        public virtual int usp_WeatherByDay_Insert(Nullable<int> cityID, Nullable<double> tempDay, Nullable<double> tempNight, string weather, string weatherIcon)
        {
            var cityIDParameter = cityID.HasValue ?
                new ObjectParameter("CityID", cityID) :
                new ObjectParameter("CityID", typeof(int));
    
            var tempDayParameter = tempDay.HasValue ?
                new ObjectParameter("TempDay", tempDay) :
                new ObjectParameter("TempDay", typeof(double));
    
            var tempNightParameter = tempNight.HasValue ?
                new ObjectParameter("TempNight", tempNight) :
                new ObjectParameter("TempNight", typeof(double));
    
            var weatherParameter = weather != null ?
                new ObjectParameter("Weather", weather) :
                new ObjectParameter("Weather", typeof(string));
    
            var weatherIconParameter = weatherIcon != null ?
                new ObjectParameter("WeatherIcon", weatherIcon) :
                new ObjectParameter("WeatherIcon", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_WeatherByDay_Insert", cityIDParameter, tempDayParameter, tempNightParameter, weatherParameter, weatherIconParameter);
        }
    
        public virtual int usp_WeatherByDay_Update(Nullable<int> weatherID, Nullable<double> tempDay, Nullable<double> tempNight, string weather, string weatherIcon)
        {
            var weatherIDParameter = weatherID.HasValue ?
                new ObjectParameter("WeatherID", weatherID) :
                new ObjectParameter("WeatherID", typeof(int));
    
            var tempDayParameter = tempDay.HasValue ?
                new ObjectParameter("TempDay", tempDay) :
                new ObjectParameter("TempDay", typeof(double));
    
            var tempNightParameter = tempNight.HasValue ?
                new ObjectParameter("TempNight", tempNight) :
                new ObjectParameter("TempNight", typeof(double));
    
            var weatherParameter = weather != null ?
                new ObjectParameter("Weather", weather) :
                new ObjectParameter("Weather", typeof(string));
    
            var weatherIconParameter = weatherIcon != null ?
                new ObjectParameter("WeatherIcon", weatherIcon) :
                new ObjectParameter("WeatherIcon", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_WeatherByDay_Update", weatherIDParameter, tempDayParameter, tempNightParameter, weatherParameter, weatherIconParameter);
        }
    }
}

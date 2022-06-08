# BlazorRollDateTimePicker

rolldate is a mobile-first, iOS-style, multi-format date picker component that uses better-scroll library for smooth scroll experience on the mobile & desktop.

## Install
`
Install-Package BlazorVideoPlayer -Version x.x.x
`

or 
[Latest Version](https://www.nuget.org/packages/BlazorVideoPlayer/)

## Use

```
<DateTimePicker Identifier="date1" PlaceHolder="select date ..." @bind-Value="value" Options="@(new DateTimePickerOption{BeginYear=1350,EndYear=1420,DateFormat="YYYY/MM/DD",Language=new Language{Cancel="Cancel",Confirm="Confirm" ,Day="Day",Hour="Hour",Min="Min",Month="Month",Sec="Sec",Title="Date",Year="Year"}})" />
```

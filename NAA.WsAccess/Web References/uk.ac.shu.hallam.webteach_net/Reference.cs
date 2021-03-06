﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using NAA.WsAccess.Properties;

#pragma warning disable 1591

namespace NAA.WsAccess.uk.ac.shu.hallam.webteach_net {
    /// <remarks/>
    [GeneratedCode("System.Web.Services", "4.7.2556.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [WebServiceBinding(Name="SheffieldWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class SheffieldWebService : SoapHttpClientProtocol {
        
        private SendOrPostCallback SheffCoursesOperationCompleted;
        
        private SendOrPostCallback SheffCoursesInShortOperationCompleted;
        
        private SendOrPostCallback HelloWorldOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SheffieldWebService() {
            this.Url = Settings.Default.NAA_WsAccess_uk_ac_shu_hallam_webteach_net_SheffieldWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SheffCoursesCompletedEventHandler SheffCoursesCompleted;
        
        /// <remarks/>
        public event SheffCoursesInShortCompletedEventHandler SheffCoursesInShortCompleted;
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        [SoapDocumentMethod("http://tempuri.org/SheffCourses", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public Course[] SheffCourses() {
            object[] results = this.Invoke("SheffCourses", new object[0]);
            return ((Course[])(results[0]));
        }
        
        /// <remarks/>
        public void SheffCoursesAsync() {
            this.SheffCoursesAsync(null);
        }
        
        /// <remarks/>
        public void SheffCoursesAsync(object userState) {
            if ((this.SheffCoursesOperationCompleted == null)) {
                this.SheffCoursesOperationCompleted = new SendOrPostCallback(this.OnSheffCoursesOperationCompleted);
            }
            this.InvokeAsync("SheffCourses", new object[0], this.SheffCoursesOperationCompleted, userState);
        }
        
        private void OnSheffCoursesOperationCompleted(object arg) {
            if ((this.SheffCoursesCompleted != null)) {
                InvokeCompletedEventArgs invokeArgs = ((InvokeCompletedEventArgs)(arg));
                this.SheffCoursesCompleted(this, new SheffCoursesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [SoapDocumentMethod("http://tempuri.org/SheffCoursesInShort", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public SSheffCourse[] SheffCoursesInShort() {
            object[] results = this.Invoke("SheffCoursesInShort", new object[0]);
            return ((SSheffCourse[])(results[0]));
        }
        
        /// <remarks/>
        public void SheffCoursesInShortAsync() {
            this.SheffCoursesInShortAsync(null);
        }
        
        /// <remarks/>
        public void SheffCoursesInShortAsync(object userState) {
            if ((this.SheffCoursesInShortOperationCompleted == null)) {
                this.SheffCoursesInShortOperationCompleted = new SendOrPostCallback(this.OnSheffCoursesInShortOperationCompleted);
            }
            this.InvokeAsync("SheffCoursesInShort", new object[0], this.SheffCoursesInShortOperationCompleted, userState);
        }
        
        private void OnSheffCoursesInShortOperationCompleted(object arg) {
            if ((this.SheffCoursesInShortCompleted != null)) {
                InvokeCompletedEventArgs invokeArgs = ((InvokeCompletedEventArgs)(arg));
                this.SheffCoursesInShortCompleted(this, new SheffCoursesInShortCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [SoapDocumentMethod("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=SoapBindingUse.Literal, ParameterStyle=SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                InvokeCompletedEventArgs invokeArgs = ((InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            Uri wsUri = new Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [GeneratedCode("System.Xml", "4.7.2612.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace="http://tempuri.org/")]
    public partial class Course {
        
        private int idField;
        
        private string nameField;
        
        private string descriptionField;
        
        private string entryReqField;
        
        private int tarifField;
        
        private string universityField;
        
        private int nSSField;
        
        private string qulaificationField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string EntryReq {
            get {
                return this.entryReqField;
            }
            set {
                this.entryReqField = value;
            }
        }
        
        /// <remarks/>
        public int Tarif {
            get {
                return this.tarifField;
            }
            set {
                this.tarifField = value;
            }
        }
        
        /// <remarks/>
        public string University {
            get {
                return this.universityField;
            }
            set {
                this.universityField = value;
            }
        }
        
        /// <remarks/>
        public int NSS {
            get {
                return this.nSSField;
            }
            set {
                this.nSSField = value;
            }
        }
        
        /// <remarks/>
        public string Qulaification {
            get {
                return this.qulaificationField;
            }
            set {
                this.qulaificationField = value;
            }
        }
    }
    
    /// <remarks/>
    [GeneratedCode("System.Xml", "4.7.2612.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace="http://tempuri.org/")]
    public partial class SSheffCourse {
        
        private int idField;
        
        private string nameField;
        
        private string descriptionField;
        
        private string entryReqField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string EntryReq {
            get {
                return this.entryReqField;
            }
            set {
                this.entryReqField = value;
            }
        }
    }
    
    /// <remarks/>
    [GeneratedCode("System.Web.Services", "4.7.2556.0")]
    public delegate void SheffCoursesCompletedEventHandler(object sender, SheffCoursesCompletedEventArgs e);
    
    /// <remarks/>
    [GeneratedCode("System.Web.Services", "4.7.2556.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class SheffCoursesCompletedEventArgs : AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SheffCoursesCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Course[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Course[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [GeneratedCode("System.Web.Services", "4.7.2556.0")]
    public delegate void SheffCoursesInShortCompletedEventHandler(object sender, SheffCoursesInShortCompletedEventArgs e);
    
    /// <remarks/>
    [GeneratedCode("System.Web.Services", "4.7.2556.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class SheffCoursesInShortCompletedEventArgs : AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SheffCoursesInShortCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public SSheffCourse[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((SSheffCourse[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [GeneratedCode("System.Web.Services", "4.7.2556.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [GeneratedCode("System.Web.Services", "4.7.2556.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class HelloWorldCompletedEventArgs : AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace WcfPhoneAppTest1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="Service", ConfigurationName="ServiceReference1.IPSRemoting")]
    public interface IPSRemoting {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Service/IPSRemoting/malZwei", ReplyAction="Service/IPSRemoting/malZweiResponse")]
        System.IAsyncResult BeginmalZwei(int value, System.AsyncCallback callback, object asyncState);
        
        int EndmalZwei(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="Service/IPSRemoting/invokeCommand", ReplyAction="Service/IPSRemoting/invokeCommandResponse")]
        System.IAsyncResult BegininvokeCommand(string value, System.AsyncCallback callback, object asyncState);
        
        string EndinvokeCommand(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPSRemotingChannel : WcfPhoneAppTest1.ServiceReference1.IPSRemoting, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class malZweiCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public malZweiCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class invokeCommandCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public invokeCommandCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PSRemotingClient : System.ServiceModel.ClientBase<WcfPhoneAppTest1.ServiceReference1.IPSRemoting>, WcfPhoneAppTest1.ServiceReference1.IPSRemoting {
        
        private BeginOperationDelegate onBeginmalZweiDelegate;
        
        private EndOperationDelegate onEndmalZweiDelegate;
        
        private System.Threading.SendOrPostCallback onmalZweiCompletedDelegate;
        
        private BeginOperationDelegate onBegininvokeCommandDelegate;
        
        private EndOperationDelegate onEndinvokeCommandDelegate;
        
        private System.Threading.SendOrPostCallback oninvokeCommandCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public PSRemotingClient() {
        }
        
        public PSRemotingClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PSRemotingClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PSRemotingClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PSRemotingClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<malZweiCompletedEventArgs> malZweiCompleted;
        
        public event System.EventHandler<invokeCommandCompletedEventArgs> invokeCommandCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult WcfPhoneAppTest1.ServiceReference1.IPSRemoting.BeginmalZwei(int value, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginmalZwei(value, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int WcfPhoneAppTest1.ServiceReference1.IPSRemoting.EndmalZwei(System.IAsyncResult result) {
            return base.Channel.EndmalZwei(result);
        }
        
        private System.IAsyncResult OnBeginmalZwei(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int value = ((int)(inValues[0]));
            return ((WcfPhoneAppTest1.ServiceReference1.IPSRemoting)(this)).BeginmalZwei(value, callback, asyncState);
        }
        
        private object[] OnEndmalZwei(System.IAsyncResult result) {
            int retVal = ((WcfPhoneAppTest1.ServiceReference1.IPSRemoting)(this)).EndmalZwei(result);
            return new object[] {
                    retVal};
        }
        
        private void OnmalZweiCompleted(object state) {
            if ((this.malZweiCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.malZweiCompleted(this, new malZweiCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void malZweiAsync(int value) {
            this.malZweiAsync(value, null);
        }
        
        public void malZweiAsync(int value, object userState) {
            if ((this.onBeginmalZweiDelegate == null)) {
                this.onBeginmalZweiDelegate = new BeginOperationDelegate(this.OnBeginmalZwei);
            }
            if ((this.onEndmalZweiDelegate == null)) {
                this.onEndmalZweiDelegate = new EndOperationDelegate(this.OnEndmalZwei);
            }
            if ((this.onmalZweiCompletedDelegate == null)) {
                this.onmalZweiCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnmalZweiCompleted);
            }
            base.InvokeAsync(this.onBeginmalZweiDelegate, new object[] {
                        value}, this.onEndmalZweiDelegate, this.onmalZweiCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult WcfPhoneAppTest1.ServiceReference1.IPSRemoting.BegininvokeCommand(string value, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegininvokeCommand(value, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string WcfPhoneAppTest1.ServiceReference1.IPSRemoting.EndinvokeCommand(System.IAsyncResult result) {
            return base.Channel.EndinvokeCommand(result);
        }
        
        private System.IAsyncResult OnBegininvokeCommand(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string value = ((string)(inValues[0]));
            return ((WcfPhoneAppTest1.ServiceReference1.IPSRemoting)(this)).BegininvokeCommand(value, callback, asyncState);
        }
        
        private object[] OnEndinvokeCommand(System.IAsyncResult result) {
            string retVal = ((WcfPhoneAppTest1.ServiceReference1.IPSRemoting)(this)).EndinvokeCommand(result);
            return new object[] {
                    retVal};
        }
        
        private void OninvokeCommandCompleted(object state) {
            if ((this.invokeCommandCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.invokeCommandCompleted(this, new invokeCommandCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void invokeCommandAsync(string value) {
            this.invokeCommandAsync(value, null);
        }
        
        public void invokeCommandAsync(string value, object userState) {
            if ((this.onBegininvokeCommandDelegate == null)) {
                this.onBegininvokeCommandDelegate = new BeginOperationDelegate(this.OnBegininvokeCommand);
            }
            if ((this.onEndinvokeCommandDelegate == null)) {
                this.onEndinvokeCommandDelegate = new EndOperationDelegate(this.OnEndinvokeCommand);
            }
            if ((this.oninvokeCommandCompletedDelegate == null)) {
                this.oninvokeCommandCompletedDelegate = new System.Threading.SendOrPostCallback(this.OninvokeCommandCompleted);
            }
            base.InvokeAsync(this.onBegininvokeCommandDelegate, new object[] {
                        value}, this.onEndinvokeCommandDelegate, this.oninvokeCommandCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override WcfPhoneAppTest1.ServiceReference1.IPSRemoting CreateChannel() {
            return new PSRemotingClientChannel(this);
        }
        
        private class PSRemotingClientChannel : ChannelBase<WcfPhoneAppTest1.ServiceReference1.IPSRemoting>, WcfPhoneAppTest1.ServiceReference1.IPSRemoting {
            
            public PSRemotingClientChannel(System.ServiceModel.ClientBase<WcfPhoneAppTest1.ServiceReference1.IPSRemoting> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginmalZwei(int value, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = value;
                System.IAsyncResult _result = base.BeginInvoke("malZwei", _args, callback, asyncState);
                return _result;
            }
            
            public int EndmalZwei(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("malZwei", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BegininvokeCommand(string value, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = value;
                System.IAsyncResult _result = base.BeginInvoke("invokeCommand", _args, callback, asyncState);
                return _result;
            }
            
            public string EndinvokeCommand(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("invokeCommand", _args, result)));
                return _result;
            }
        }
    }
}
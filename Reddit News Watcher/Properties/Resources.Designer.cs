﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reddit_News_Watcher.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Reddit_News_Watcher.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;span class=&quot;domain&quot;&gt;\(&lt;a href=&quot;\S+&quot;&gt;(\S+)&lt;\/a&gt;.
        /// </summary>
        internal static string DomainRegex {
            get {
                return ResourceManager.GetString("DomainRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;span class=&quot;rank&quot;&gt;(\d+)&lt;\/span&gt;.
        /// </summary>
        internal static string RankRegex {
            get {
                return ResourceManager.GetString("RankRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;a class=&quot;title \S+ \S+&quot; data-event-action=&quot;title&quot; href=&quot;(\S+)&quot;.
        /// </summary>
        internal static string SourceRegex {
            get {
                return ResourceManager.GetString("SourceRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p class=&quot;tagline &quot;&gt;.+?&lt;time title=&quot;(.+?)&quot; datetime=&quot;.+?&quot; class=&quot;live-timestamp&quot;&gt;(.+?)&lt;\/time&gt;.+?&lt;a href=&quot;(.+?)&quot; class=&quot;.+?&quot; &gt;(.+?)&lt;\/a&gt;.
        /// </summary>
        internal static string TaglineRegex {
            get {
                return ResourceManager.GetString("TaglineRegex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to data-outbound-expiration=&quot;.+? &gt;(.+?)&lt;\/a&gt;.+?&lt;span class=&quot;domain&quot;&gt;.
        /// </summary>
        internal static string TitleRegex {
            get {
                return ResourceManager.GetString("TitleRegex", resourceCulture);
            }
        }
    }
}

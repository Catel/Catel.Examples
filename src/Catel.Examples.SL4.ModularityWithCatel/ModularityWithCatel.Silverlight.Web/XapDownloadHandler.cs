//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
namespace ModularityWithCatel.Silverlight.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Threading;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Slows the incremental download of XAP files for Modularity Quickstart purposes.
    /// </summary>
    public class XapDownloadHandler : IHttpHandler
    {
        // The default percentage of the file size per chunk transmitted is 10%
        private const double DefaultTransmitChunkPercent = 0.1;

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get { return true; }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            string physicalPath = context.Server.MapPath(context.Request.Path);

            // Different modules are slowed down by different amounts for illustration purposes in the quickstart.
            if (context.Request.Path.Contains("ModuleB"))
            {
                this.SlowlyTransmitFile(context, physicalPath, 100);
            }
            else if (context.Request.Path.Contains("ModuleD"))
            {
                this.SlowlyTransmitFile(context, physicalPath, 200);
            }
            else if (context.Request.Path.Contains("ModuleE"))
            {
                // Module F depends on Module E, so I make it take much longer so that the difference is visible in the quickstart.
                this.SlowlyTransmitFile(context, physicalPath, 600);
            }
            else if (context.Request.Path.Contains("ModuleF"))
            {                
                this.SlowlyTransmitFile(context, physicalPath, 300);
            }
            else
            {
                this.SlowlyTransmitFile(context, physicalPath, 0);
            }
            
        }
        
        
        // This method provides the actual slow-down and incremental transmittion.
        private void SlowlyTransmitFile(HttpContext context, string path, int milliSecondsDelayPerChunk)
        {
            // The output must be unbufferred to allow for the client to receive chunks separately.
            context.Response.BufferOutput = false;

            // So that the client can display progress as chunks are downloaded, we output the Content-length header.
            long fileSize = -1L;
            if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                fileSize = fileInfo.Length;
            }
            context.Response.AppendHeader("Content-Length", fileSize.ToString());

            // Read the file and calculate the number of even chunks + the leftover chunk.
            byte[] moduleBuffer = File.ReadAllBytes(path);
            byte[] chunkBufer;
            int chunkSize = (int)((double)moduleBuffer.Length * DefaultTransmitChunkPercent);
            int chunkCount = moduleBuffer.Length / chunkSize;
            int leftOverSize = moduleBuffer.Length % chunkSize;
            int i = 0;

            // Send each chunk and wait per chunck set.
            if (chunkCount > 0)
            {
                chunkBufer = new byte[chunkSize];
                while (i < chunkCount * chunkSize)
                {
                    Array.Copy(moduleBuffer, i, chunkBufer, 0, chunkSize);
                    context.Response.BinaryWrite(chunkBufer);
                    i += chunkSize;

                    Thread.Sleep(milliSecondsDelayPerChunk);
                }
            }

            // Send the last leftover chunk (no waiting).
            if (leftOverSize != 0)
            {
                chunkBufer = new byte[leftOverSize];
                Array.Copy(moduleBuffer, i, chunkBufer, 0, leftOverSize);
                context.Response.BinaryWrite(chunkBufer);
            }
        }        

    }
}
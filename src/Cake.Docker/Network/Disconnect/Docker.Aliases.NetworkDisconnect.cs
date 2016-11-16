﻿using Cake.Core;
using Cake.Core.Annotations;
using System;
using System.Collections.Generic;

namespace Cake.Docker
{
    /// <summary>
    /// Contains functionality for working with network disconnect command.
    /// </summary>
    [CakeAliasCategory("Docker")] 
    partial class DockerAliases
    {
        /// <summary>
        /// Disconnects a network using default settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerNetworkDisconnect(this ICakeContext context, params string[] args)
        {
            DockerNetworkDisconnect(context, new DockerNetworkDisconnectSettings(), args);
        }

        /// <summary>
        /// Disconnects a network given <paramref name="settings"/>.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="args">The arguments.</param>
        [CakeMethodAlias]
        public static void DockerNetworkDisconnect(this ICakeContext context, DockerNetworkDisconnectSettings settings, params string[] args)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var runner = new GenericDockerRunner<DockerNetworkDisconnectSettings>(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
            List<string> arguments = new List<string> ();
            if (args.Length > 0)
            {
                arguments.AddRange(args);
            }
            runner.Run("network disconnect", settings ?? new DockerNetworkDisconnectSettings(), arguments.ToArray());
        }
    }
}

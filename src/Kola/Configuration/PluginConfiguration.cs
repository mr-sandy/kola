using System.Collections.Generic;

namespace Kola.Configuration
{
    internal class PluginConfiguration
    {
        private List<AtomConfiguration> atoms = new List<AtomConfiguration>();

        public string ViewLocation { get; set; }

        public AtomConfiguration ConfigureAtom(string atomName)
        {
            var config = new AtomConfiguration(atomName);
            this.atoms.Add(config);
            return config;
        }

        public ContainerConfiguration ConfigureContainer(string containerName)
        {
            return new ContainerConfiguration(containerName);
        }

        public ParameterTypeConfiguration ConfigureParameterType(string parameterTypeName)
        {
            return new ParameterTypeConfiguration(parameterTypeName);
        }

        internal IEnumerable<AtomConfiguration> Atoms
        {
            get { return this.atoms; }
        }
    }
}

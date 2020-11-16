// Copyright 2018 Confluent Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Refer to LICENSE for more information.

using Avro.Reflect;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Confluent.SchemaRegistry.Serdes
{
    internal class ReflectSerializerImpl<T> : IAvroSerializerImpl<T>
    {
        private ISchemaRegistryClient schemaRegistryClient;

        private bool autoRegisterSchema;

        private int initialBufferSize;

        private SubjectNameStrategyDelegate subjectNameStrategy;

        private SerializerSchemaData<T> schemaData = null;

        private SemaphoreSlim serializeMutex = new SemaphoreSlim(1);

        public ReflectSerializerImpl(
            ISchemaRegistryClient schemaRegistryClient,
            bool autoRegisterSchema,
            int initialBufferSize,
            SubjectNameStrategyDelegate subjectNameStrategy)
        {
            this.schemaRegistryClient = schemaRegistryClient;
            this.autoRegisterSchema = autoRegisterSchema;
            this.initialBufferSize = initialBufferSize;
            this.subjectNameStrategy = subjectNameStrategy;
            this.schemaData = ExtractSchemaData(typeof(T));
        }

        private static SerializerSchemaData<T> ExtractSchemaData(Type writerType)
        {
            // TODO: generate schema from type
            global::Avro.Schema writerSchema = null;

            ReflectWriter<T> avroWriter = new ReflectWriter<T>(new ReflectDefaultWriter(writerSchema));
            return new SerializerSchemaData<T>(avroWriter);
        }

        public Task<byte[]> Serialize(string topic, T data, bool isKey)
        {
            // TODO: basically copy (or reuse) most of what's in SpecificSerializerImpl.Serialize()
            throw new System.NotImplementedException();
        }
    }
}
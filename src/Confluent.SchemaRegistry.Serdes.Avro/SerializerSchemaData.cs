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

using Avro.Generic;
using System.Collections.Generic;

namespace Confluent.SchemaRegistry.Serdes
{
        internal class SerializerSchemaData<T>
        {
            private string writerSchemaString;
            private global::Avro.Schema writerSchema;

            /// <remarks>
            ///     A given schema is uniquely identified by a schema id, even when
            ///     registered against multiple subjects.
            /// </remarks>
            private int? writerSchemaId;

            private DatumWriter<T> avroWriter;

            private HashSet<string> subjectsRegistered = new HashSet<string>();

            public SerializerSchemaData(DatumWriter<T> avroWriter)
            {
                this.avroWriter = avroWriter;
                this.writerSchema = avroWriter.Schema;
                this.writerSchemaString = avroWriter.Schema.ToString();
            }

            public HashSet<string> SubjectsRegistered
            {
                get => subjectsRegistered;
                set => subjectsRegistered = value;
            }

            public string WriterSchemaString
            {
                get => writerSchemaString;
                set => writerSchemaString = value;
            }

            public Avro.Schema WriterSchema
            {
                get => writerSchema;
                set => writerSchema = value;
            }

            public int? WriterSchemaId
            {
                get => writerSchemaId;
                set => writerSchemaId = value;
            }

            public DatumWriter<T> AvroWriter
            {
                get => avroWriter;
                set => avroWriter = value;
            }
        }
}

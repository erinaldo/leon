using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

//feb 1.9.1
namespace OFC
{
    class FacturacionWeb
    {
        XElement comprobante;
        XElement cliente;
        XElement comprobanteDetalle;
        XElement[] conceptos;

        public FacturacionWeb(int cantidadDeConceptos)
        {
            conceptos = new XElement[cantidadDeConceptos];
        }

        private XElement generarConceptos(int cantidad, int unidad, string codigo, string detalle, decimal importe, 
            decimal bonificacion, int alicuota, decimal impIVA, decimal impTotalConcepto)
        {
            XElement concepto =
            new XElement("conceptos",
            new XElement("cantidad", cantidad),
            new XElement("unidad", unidad),
            new XElement("codigo", codigo),
            new XElement("detalle", detalle),
            new XElement("importe", importe),
            new XElement("bonificacion", bonificacion),
            new XElement("alicuota", alicuota),
            new XElement("impIVA", impIVA),
            new XElement("impTotalConcepto", impTotalConcepto)
            );
            return concepto;
        }

        public void setConceptos(string tipo_comprobante, long id_origen, string alicuota)
        {
            if (tipo_comprobante == "FACTURA")
            {
                FacturaDetalle _facturaDetalle = new FacturaDetalle();
                _facturaDetalle.getDataFW(id_origen, alicuota);

                int i = 0;
                foreach (FacturaDetalleDTO detalleFact in _facturaDetalle.DataListFW)
                {
                    conceptos[i] = this.generarConceptos(detalleFact.Cantidad, detalleFact.Fw_unidad, detalleFact.Codigo, detalleFact.Descripcion, detalleFact.Precio_unitario, detalleFact.Fw_porcentajeBonificacion, detalleFact.Fw_alicuota, detalleFact.Fw_importeIva, detalleFact.Fw_totalConcepto);
                    i = i + 1;
                }
            }

            if (tipo_comprobante == "CREDITO")
            {

            }

            if (tipo_comprobante == "DEBITO")
            {

            }
        }

        public void setDetalleDelComprobante(string tipo_comprobante, long id_origen, char tipo_factura, long nro_remito)
        {
            if (tipo_comprobante == "FACTURA")
            {
                string cod_comprobante_remito = string.Empty;
                if (nro_remito == -1){
                    cod_comprobante_remito = RemitoDTO.getComprobanteTemp();
                }
                else{
                    cod_comprobante_remito = ComprobanteDTO.converToNroRemito(nro_remito.ToString());
                }

                string tipo_comprobante_aux = tipo_comprobante + " " + tipo_factura;
                Factura _factura = new Factura();
                _factura.getDataFW(id_origen);
                comprobanteDetalle = this.generarComprobanteDetalle(
                    int.Parse(ValorDTO.obtenerValorAdicional("FW", "comprobante/comprobanteDetalle/origen")),
                    _factura.DataFW.Id_unico_comprobante,
                    (int) ValorDTO.obtenerIdExterno("TC", tipo_comprobante_aux), 
                    _factura.DataFW.Fw_concepto,
                    _factura.DataFW.Total,
                    0,
                    0,
                    _factura.DataFW.Subtotal,
                    0,
                    _factura.DataFW.BaseImp3,
                    _factura.DataFW.ImpIVA3,
                    _factura.DataFW.BaseImp4,
                    _factura.DataFW.ImpIVA4,
                    _factura.DataFW.BaseImp5,
                    _factura.DataFW.ImpIVA5,
                    _factura.DataFW.BaseImp6,
                    _factura.DataFW.ImpIVA6,
                    ValorDTO.obtenerValorAdicional("FW", "comprobante/comprobanteDetalle/puntoVenta"),
                    _factura.DataFW.V_fecha_creacion,
                    _factura.DataFW.Fw_id_condicion_venta,
                    cod_comprobante_remito,
                    "",
                    conceptos.Length);
            }

            if (tipo_comprobante == "CREDITO")
            {

            }

            if (tipo_comprobante == "DEBITO")
            {

            }

        }

        public XElement generarComprobanteDetalle(int origen, long id, int cbteTipo, int concepto, 
            decimal impTotal, decimal impOpEx, decimal impTotConc, decimal impNeto,
            decimal impTrib, decimal baseImp3, decimal impIVA3, decimal baseImp4, decimal impIVA4,
            decimal baseImp5, decimal impIVA5, decimal baseImp6, decimal impIVA6, string puntoVenta,
            string cbteFch, int condicionVta, string remito, string observaciones, int cantConceptos)
        {
            comprobanteDetalle =
            new XElement("comprobanteDetalle",
            new XElement("origen", origen),
            new XElement("id", id),
            new XElement("cbteTipo", cbteTipo),
            new XElement("concepto", concepto),
            new XElement("impTotal", impTotal),
            new XElement("impOpEx", impOpEx),
            new XElement("impTotConc", impTotConc),
            new XElement("impNeto", impNeto),
            new XElement("impTrib", impTrib),
            new XElement("baseImp3", baseImp3),
            new XElement("impIVA3", impIVA3),
            new XElement("baseImp4", baseImp4),
            new XElement("impIVA4", impIVA4),
            new XElement("baseImp5", baseImp5),
            new XElement("impIVA5", impIVA5),
            new XElement("baseImp6", baseImp6),
            new XElement("impIVA6", impIVA6),
            new XElement("puntoVenta", puntoVenta),
            new XElement("cbteFch", cbteFch),
            new XElement("condicionVta", condicionVta),
            new XElement("remito", remito),
            new XElement("observaciones", observaciones),
            new XElement("cantConceptos", cantConceptos)
            );

            for(int i = 0 ; i < conceptos.Length ; i++)
            {
                comprobanteDetalle.Add(conceptos[i]);
            }

            return comprobanteDetalle;
        }

        public XElement generarCliente(int docTipo, string docNro, string email, string emailAlternativo,
            int tipoPersona, string nombre, string apellido, string razonSocial, int condicion, string direccion,
            string ciudad, int provincia, string cp, string telefono, string celular)
        {
            cliente =
            new XElement("cliente",
            new XElement("docTipo", docTipo),
            new XElement("docNro", docNro),
            new XElement("email", email),
            new XElement("emailAlternativo", emailAlternativo),
            new XElement("tipoPersona", tipoPersona),
            new XElement("nombre", nombre),
            new XElement("apellido", apellido),
            new XElement("razonSocial", razonSocial),
            new XElement("condicion", condicion),
            new XElement("direccion", direccion),
            new XElement("ciudad", ciudad),
            new XElement("provincia", provincia),
            new XElement("cp", cp),
            new XElement("telefono", telefono),
            new XElement("celular", celular)
            );

            return cliente;
        }

        public void setCliente(string id_cliente)
        {
            Clientes _cliente = new Clientes(); //para mejorar hacer un constructor que no levante los datos de clientes
            _cliente.getDataFW(id_cliente);
            bool faltanDatos = validarDatosCliente(_cliente.DataFW);
            if (faltanDatos)
            {
                Exception ex = new Exception();
                throw new Exception("Faltan algunos datos del cliente.", ex);
            }
            else
            {
                cliente = this.generarCliente(_cliente.DataFW.Fw_id_tipo_documento_externo,
                    _cliente.DataFW.Cuit,
                    _cliente.DataFW.Email,
                    "",
                    _cliente.DataFW.Fw_id_tipo_persona_externo,
                    _cliente.DataFW.Nombre_persona,
                    _cliente.DataFW.Apellido_persona,
                    _cliente.DataFW.Nombre,
                    _cliente.DataFW.Fw_id_condicion_iva_externo,
                    _cliente.DataFW.Direccion_legal,
                    _cliente.DataFW.Localidad_legal,
                    _cliente.DataFW.Fw_id_provincia_externo,
                    _cliente.DataFW.Codigo_postal,
                    _cliente.DataFW.Telefono_fijo,
                    _cliente.DataFW.Telefono_movil);
            }
        }

        private bool validarDatosCliente (ClienteDTO cliente){

            bool faltanDatos = false;

            if (cliente.Fw_id_tipo_persona_externo == -1 || cliente.Fw_id_provincia_externo == -1 || cliente.Fw_id_condicion_iva_externo == -1 || cliente.Email == string.Empty)
            {
                faltanDatos = true;
            }

            if (ValorDTO.obtenerValor("TP", cliente.Fw_id_tipo_persona_externo) == "JURIDICA" && cliente.Nombre == string.Empty)
            {
                faltanDatos = true;
            }

            if (ValorDTO.obtenerValor("TP", cliente.Fw_id_tipo_persona_externo) == "FISICA")
            {
                if (cliente.Nombre_persona == string.Empty || cliente.Apellido_persona == string.Empty)
                {
                    faltanDatos = true;
                }
            }

            return faltanDatos;
        }
            

        public void generarComprobante()
        {
            comprobante =
            new XElement("comprobante",
            new XElement(cliente),
            new XElement(comprobanteDetalle)
            );
        }

        public XElement getComprobante()
        {
            return comprobante;
        }

        public static XElement generarFW(int cantComprobantes, XElement[] comprobante)
        {
            XElement FW =
            new XElement("FW",
            new XElement("cantComprobantes", cantComprobantes));

            for(int i = 0 ; i < comprobante.Length ; i++)
            {
                FW.Add(comprobante[i]);
            }
            return FW;
        }

        public static string generarXML(Factura _factura)
        {
            try
            {

                string path_archivo = string.Empty;
                string nombre_archivo = string.Empty;
                string path_completo = string.Empty;
                string nroDeFactura = string.Empty;
                string nroDeFacturaTipo = string.Empty;
                XElement[] comprobantes = new XElement[_factura.GridDataList.Count];
                int i = 0;

                foreach (FacturaDTO row in _factura.GridDataList)
                {
                    //por factura
                    if (row.Tipo_factura == 'A')
                    {
                        nroDeFactura = ComprobanteDTO.converToNroFacturaA(row.Nro_factura.ToString());
                        nroDeFacturaTipo = "A-" + nroDeFactura;
                    }
                    if (row.Tipo_factura == 'B')
                    {
                        nroDeFactura = ComprobanteDTO.converToNroFacturaB(row.Nro_factura.ToString());
                        nroDeFacturaTipo = "B-" + nroDeFactura;
                    }
                    FacturacionWeb xmlFactura = new FacturacionWeb(FacturaDTO.obtenerCantidadDeConceptos(row.Id));

                    if (row.Iva105 == 'N')
                    {
                        xmlFactura.setConceptos("FACTURA", row.Id, "IVA_21");
                    }
                    else
                    {
                        xmlFactura.setConceptos("FACTURA", row.Id, "IVA_105");
                    }
                    xmlFactura.setDetalleDelComprobante("FACTURA", row.Id, row.Tipo_factura, row.Nro_remito);
                    xmlFactura.setCliente(row.Id_cliente);
                    xmlFactura.generarComprobante();
                    comprobantes[i] = xmlFactura.getComprobante();
                    i = i + 1;
                }
                XElement FW = FacturacionWeb.generarFW(i, comprobantes);
                path_archivo = ParametroDTO.obtenerParametroIII("PATH_ARCHIVO_FACTURACION_WEB");
                nombre_archivo = ParametroDTO.obtenerParametroIII("NOMBRE_ARCHIVO_FACTURACION_WEB");
                path_completo = path_archivo + nombre_archivo + "_factura_" + nroDeFacturaTipo + ".xml";

                //esencial para que no ponga caracteres raros, hay que definir el formato utf
                TextWriter writer = new StreamWriter(path_completo, false, new UTF8Encoding(false));
                FW.Save(writer);

                return path_completo;

            }
            catch (Exception ex)
            {
                throw new Exception("No ha sido posible exportar las facturas. Intente nuevamente, si el problema persiste contacte al administrador del sistema.", ex);
            }
        }

    }
}

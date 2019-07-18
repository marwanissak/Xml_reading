using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace xml_reading
{
    public partial class Main_page : System.Web.UI.Page
    {
        XmlDocument xml = new XmlDocument();
        XmlNodeList xml_node_List;


        //==== Läsa från filen ====//
        void Read_From_file()
        {
            xml.Load("/books.xml");
            xml_node_List = xml.SelectNodes("/catalog/book");
        }
       
        //==== Söka i xml filen ===//
        void search_in_xmlfile()
        {
            foreach (XmlNode xml_node in xml_node_List)
            {
                if (Input_word.Text == xml_node["title"].InnerText)
                {
                    Result_output.Text = xml_node["author"].InnerText;
                    genre_output.Text = xml_node["genre"].InnerText;
                    price_output.Text = xml_node["price"].InnerText;
                    publish_date_output.Text = xml_node["publish_date"].InnerText;
                    description_output.Text = xml_node["description"].InnerText;
                    return;
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Unfortunately the book does not exist!');", true);
        }

        //=== Specifika sökningar för böcker som har gemensamma egenskaper===//
        void search_spesific_in_xmlfile()
        {
            result_TB_spesific.Text = "";
            foreach (XmlNode xml_node in xml_node_List)
            {
                switch (search_by_specific.SelectedIndex)
                {
                    case 0:

                        if (spesific_search_input_TB.Text == xml_node["author"].InnerText)
                        {
                            result_TB_spesific.Text += (xml_node["title"].InnerText+"  " + xml_node["price"].InnerText + "\n");
                        }
                        break;

                    case 1:

                        if (spesific_search_input_TB.Text == xml_node["genre"].InnerText)
                        {
                            result_TB_spesific.Text += (xml_node["title"].InnerText + "  " + xml_node["price"].InnerText + "\n");
                        }
                        break;

                    case 2:

                        if (spesific_search_input_TB.Text == xml_node["price"].InnerText)
                        {
                            result_TB_spesific.Text += (xml_node["title"].InnerText +  "\n");
                        }
                        break;

                    case 3:

                        if (spesific_search_input_TB.Text == xml_node["publish_date"].InnerText)
                        {
                            result_TB_spesific.Text += (xml_node["title"].InnerText + "  " + xml_node["price"].InnerText + "\n");
                        }
                        break;

                    default:
                        
                        break;
                }
            }
            if (result_TB_spesific.Text == "") { ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Sorry ,we dont have the book you are looking for.');", true); }
         
        }

        //=== Skriv ett ord och söka matchande rubriker ===//
        void searching_by_one_word()
        {
            titles_results_TB.Text = "";
            foreach (XmlNode xml_node in xml_node_List)
            { 
                if ( (xml_node["title"].InnerText.Contains(search_titles_by_specific_word_TB.Text)) ==true)
                {
                    titles_results_TB.Text += xml_node["title"].InnerText + "\n";          
                }    
            }
        }


        // ==== ALLA KNAPPAR ====//
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Input_word_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Search_btn_Click(object sender, EventArgs e)
        {
            Read_From_file();
            search_in_xmlfile();
        }

        protected void publish_date_output0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void search_by_specific_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void spesific_btn_Click(object sender, EventArgs e)
        {
            Read_From_file();
            search_spesific_in_xmlfile();
            show_all_tb.Text += "book id , author , title, genre ,publish-date , description" + Environment.NewLine + Environment.NewLine;
            foreach (XmlNode xml_node in xml_node_List)
            {
                show_all_tb.Text += xml_node.InnerText + Environment.NewLine+Environment.NewLine;
            }
        }

        protected void result_TB_spesific_TextChanged(object sender, EventArgs e)
        {

        }

        protected void titles_results_TB_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void search_titles_by_specific_word_TB_TextChanged(object sender, EventArgs e)
        {

        }

        protected void search_word_from_titles_Click(object sender, EventArgs e)
        {
            Read_From_file();
            searching_by_one_word();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
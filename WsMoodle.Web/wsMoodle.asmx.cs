// <copyright file="wsMoodle.asmx.cs" company="SmartIT Technologies LLC.">
// Copyright SmartIT Technologies LLC. Todos os direitos reservados.
// </copyright>
// <author>Eduardo Claudio Nicacio</author>
// <date>05/05/2015</date>
// <summary>Classe que encapsula o Webservice de integração Kepler x Moodle.</summary>

namespace WsMoodle.Web
{
    using System.Configuration;
    using System.Web.Services;
    using WsMoodle.Library.WsppMoodle;

    /// <summary>
    /// Webservice de integração com o ambiente Moodle.
    /// </summary>
    [WebService(Namespace = "http://wsmoodle.smartit.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class wsMoodle : System.Web.Services.WebService
    {
        /// <summary>
        /// Indicates if the Webservice uses proxy.
        /// </summary>
        /// <value>True or false.</value>
        public readonly static string UseProxy = ConfigurationManager.AppSettings["UseProxy"];

        /// <summary>
        /// Proxy username.
        /// </summary>
        /// <value>Default = string.Empty.</value>
        public readonly static string ProxyUsername = ConfigurationManager.AppSettings["ProxyUsername"];

        /// <summary>
        /// Proxy password.
        /// </summary>        
        /// <value>Default = string.Empty.</value>
        public readonly static string ProxyPassword = ConfigurationManager.AppSettings["ProxyPassword"];

        /// <summary>
        /// Proxy domain.
        /// </summary>
        /// <value>Default = string.Empty.</value>
        public readonly static string ProxyDomain = ConfigurationManager.AppSettings["ProxyDomain"];

        /// <summary>
        /// Proxy URL or IP address.
        /// </summary>
        /// <value>Default = string.Empty.</value>
        public readonly static string ProxyUrl = ConfigurationManager.AppSettings["ProxyUrl"];

        /// <summary>
        /// Continue in case of error.
        /// </summary>
        /// <value>Default = "TRUE".</value>
        public readonly static string ExpectContinue = ConfigurationManager.AppSettings["ExpectContinue"];

        /// <summary>
        /// Proxy port number.
        /// </summary>
        /// <value>Default = string.Empty.</value>
        public readonly static string Port = ConfigurationManager.AppSettings["Port"];

        /// <summary>
        /// Moodle Webservice (Wspp) URL.
        /// </summary>
        /// <value>http://serveraddress/moodle-instance/wspp/.</value>
        public readonly static string MoodleWsppUrl = ConfigurationManager.AppSettings["MoodleWsppUrl"];

        /// <summary>
        /// Moodle Webservice (Wspp) username.
        /// </summary>
        /// <value>Default = "wsmoodle"</value>
        public readonly static string MoodleWebserviceUsername = ConfigurationManager.AppSettings["MoodleWebserviceUsername"];

        /// <summary>
        /// Moodle Webservice (Wspp) password.
        /// </summary>
        /// <value>Default = "wsMoodle@2015".</value>
        public readonly static string MoodleWebservicePassword = ConfigurationManager.AppSettings["MoodleWebservicePassword"];

        /// <summary>
        /// Moodle Webservice (Wspp) Token.
        /// </summary>
        /// <value>Default = fac788ba1ac61e460e3d8d662f30a680 to the username and password above.</value>
        public readonly static string MoodleWebserviceToken = ConfigurationManager.AppSettings["MoodleWebserviceToken"];

        /// <summary>
        /// Do the Moodle login, using the username and password within config file.
        /// </summary>
        /// <returns>An object <seealso cref="loginReturn"/>, with the userId and the sessionKey.</returns>
        [WebMethod]
        public loginReturn Login()
        {
            return new mdl_soapserverPortTypeClient().login(MoodleWebserviceUsername, MoodleWebservicePassword);
        }

        /// <summary>
        /// Logout the user logged at this time.
        /// </summary>
        /// <returns> True, in case of success; false instead.</returns>
        [WebMethod]
        public bool Logout()
        {
            loginReturn loginReturn = this.Login();
            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            return owsMoodle.logout(loginReturn.client, loginReturn.sessionkey);
        }

        /// <summary>
        /// Adds an assignment.
        /// </summary>
        /// <param name="datum">Object <seealso cref="assignmentDatum"/>.</param>
        /// <returns>Array of <seealso cref="assignmentRecord"/>.</returns>
        [WebMethod]
        public assignmentRecord[] AddAssignment(assignmentDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            assignmentRecord[] result = owsMoodle.add_assignment(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a category.
        /// </summary>
        /// <param name="datum">Object <seealso cref="categoryDatum"/>.</param>
        /// <returns>Array of <seealso cref="categoryRecord"/>.</returns>
        [WebMethod]
        public categoryRecord[] AddCategory(categoryDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            categoryRecord[] result = owsMoodle.add_category(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a Cohort.
        /// </summary>
        /// <param name="datum">Object <seealso cref="cohortDatum"/>.</param>
        /// <returns>Array of <seealso cref="cohortRecord"/>.</returns>
        [WebMethod]
        public cohortRecord[] AddCohort(cohortDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            cohortRecord[] result = owsMoodle.add_cohort(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a database.
        /// </summary>
        /// <param name="datum">Object <seealso cref="databaseDatum"/>.</param>
        /// <returns>Array of <seealso cref="databaseRecord"/>.</returns>
        [WebMethod]
        public databaseRecord[] AddDatabase(databaseDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            databaseRecord[] result = owsMoodle.add_database(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a Forum.
        /// </summary>
        /// <param name="datum">Object <seealso cref="forumDatum"/>.</param>
        /// <returns>Array of <seealso cref="forumRecord"/>.</returns>
        [WebMethod]
        public forumRecord[] AddForum(forumDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            forumRecord[] result = owsMoodle.add_forum(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a Group.
        /// </summary>
        /// <param name="datum">Object <seealso cref="groupDatum"/>.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] AddGroup(groupDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.add_group(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a Grouping.
        /// </summary>
        /// <param name="datum">Object <seealso cref="groupingDatum"/>.</param>
        /// <returns>Array of <seealso cref="groupingRecord"/>.</returns>
        [WebMethod]
        public groupingRecord[] AddGrouping(groupingDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupingRecord[] result = owsMoodle.add_grouping(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a Label.
        /// </summary>
        /// <param name="datum">Object <seealso cref="labelDatum"/>.</param>
        /// <returns>Array of <seealso cref="labelRecord"/>.</returns>
        [WebMethod]
        public labelRecord[] AddLabel(labelDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            labelRecord[] result = owsMoodle.add_label(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds Teacher that can't edit a Course.
        /// </summary>
        /// <param name="courseid">Course ID.</param>
        /// <param name="courseidfield">Course ID field.</param>
        /// <param name="userid">User ID.</param>
        /// <param name="useridfield">User ID field.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AddNonEditingTeacher(string courseid, string courseidfield, string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.add_noneditingteacher(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Adds Wiki page.
        /// </summary>
        /// <param name="datum">Object <seealso cref="pageWikiDatum"/>.</param>
        /// <returns>Array of <seealso cref="pageWikiRecord"/>.</returns>
        [WebMethod]
        public pageWikiRecord[] AddPageWiki(pageWikiDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            pageWikiRecord[] result = owsMoodle.add_pagewiki(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a Section.
        /// </summary>
        /// <param name="datum">Object <seealso cref="sectionDatum"/>.</param>
        /// <returns>Array of <seealso cref="sectionRecord"/>.</returns>
        [WebMethod]
        public sectionRecord[] AddSection(sectionDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            sectionRecord[] result = owsMoodle.add_section(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a Student to a Course.
        /// </summary>
        /// <param name="courseid">Course ID.</param>
        /// <param name="courseidfield">Course ID field.</param>
        /// <param name="userid">User ID.</param>
        /// <param name="useridfield">User ID field.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AddStudent(string courseid, string courseidfield, string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.add_student(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Adds a Teacher to a Course.
        /// </summary>
        /// <param name="courseid">Course ID.</param>
        /// <param name="courseidfield">Course ID field.</param>
        /// <param name="userid">User ID.</param>
        /// <param name="useridfield">User ID field.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AddTeacher(string courseid, string courseidfield, string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.add_teacher(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Adds a Moodle user.
        /// </summary>
        /// <param name="datum">Object <seealso cref="userDatum"/>.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] AddUser(userDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.add_user(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Adds a new Wiki.
        /// </summary>
        /// <param name="datum">Object <seealso cref="wikiDatum"/>.</param>
        /// <returns>Array of <seealso cref="wikiRecord"/>.</returns>
        [WebMethod]
        public wikiRecord[] AddWiki(wikiDatum datum)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            wikiRecord[] result = owsMoodle.add_wiki(loginReturn.client, loginReturn.sessionkey, datum);

            return result;
        }

        /// <summary>
        /// Links an Assignment to a Section.
        /// </summary>
        /// <param name="assignmentid">Assignment id.</param>
        /// <param name="sectionid">Section id.</param>
        /// <param name="groupmode">Grouping mode.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectAssignmentToSection(int assignmentid, int sectionid, int groupmode)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_assignment_to_section(loginReturn.client, loginReturn.sessionkey, assignmentid, sectionid, groupmode);

            return result;
        }

        /// <summary>
        /// Links a Course to a Category.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="categoryid">Category id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectCourseToCategory(int courseid, int categoryid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_course_to_category(loginReturn.client, loginReturn.sessionkey, courseid, categoryid);

            return result;
        }

        /// <summary>
        /// Links a Database to a Section.
        /// </summary>
        /// <param name="databaseid">Database id.</param>
        /// <param name="sectionid">Section id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectDatabaseToSection(int databaseid, int sectionid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_database_to_section(loginReturn.client, loginReturn.sessionkey, databaseid, sectionid);

            return result;
        }

        /// <summary>
        /// Links um Forum a uma Seção.
        /// </summary>
        /// <param name="forumid">Forum id.</param>
        /// <param name="sectionid">Section id.</param>
        /// <param name="groupmode">Modo de agrupamento.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectForumToSection(int forumid, int sectionid, int groupmode)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_forum_to_section(loginReturn.client, loginReturn.sessionkey, forumid, sectionid, groupmode);

            return result;
        }

        /// <summary>
        /// Links a Group to a Course.
        /// </summary>
        /// <param name="groupid">Group id</param>
        /// <param name="courseid">Course id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectGroupToCourse(int groupid, int courseid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_group_to_course(loginReturn.client, loginReturn.sessionkey, groupid, courseid);

            return result;
        }

        /// <summary>
        /// Links a Group to a Grouping.
        /// </summary>
        /// <param name="groupid">Group id.</param>
        /// <param name="groupingid">Grouping id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectGroupToGrouping(int groupid, int groupingid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_group_to_grouping(loginReturn.client, loginReturn.sessionkey, groupid, groupingid);

            return result;
        }

        /// <summary>
        /// Links a Grouping to a Course.
        /// </summary>
        /// <param name="groupingid">Grouping id.</param>
        /// <param name="courseid">Course id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectGroupingToCourse(int groupingid, int courseid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_grouping_to_course(loginReturn.client, loginReturn.sessionkey, groupingid, courseid);

            return result;
        }

        /// <summary>
        /// Links a Label to a Section.
        /// </summary>
        /// <param name="labelid">Label id.</param>
        /// <param name="sectionid">Section id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectLabelToSection(int labelid, int sectionid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_label_to_section(loginReturn.client, loginReturn.sessionkey, labelid, sectionid);

            return result;
        }

        /// <summary>
        /// Links a Wiki Page to a Wiki.
        /// </summary>
        /// <param name="pageid">Page id.</param>
        /// <param name="wikiid">Wiki id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectPageWikiToWiki(int pageid, int wikiid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_pageWiki_to_wiki(loginReturn.client, loginReturn.sessionkey, pageid, wikiid);

            return result;
        }

        /// <summary>
        /// Links uma Seção a um Curso.
        /// </summary>
        /// <param name="sectionid">Section id.</param>
        /// <param name="courseid">Course id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectSectionToCourse(int sectionid, int courseid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_section_to_course(loginReturn.client, loginReturn.sessionkey, sectionid, courseid);

            return result;
        }

        /// <summary>
        /// Links an User to a Group (Cohort).
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="groupid">Group id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectUserToCohort(int userid, int groupid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_user_to_cohort(loginReturn.client, loginReturn.sessionkey, userid, groupid);

            return result;
        }

        /// <summary>
        /// Links an User to a Course.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="courseid">Course id.</param>
        /// <param name="rolename">Role name.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectUserToCourse(int userid, int courseid, string rolename)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_user_to_course(loginReturn.client, loginReturn.sessionkey, userid, courseid, rolename);

            return result;
        }

        /// <summary>
        /// Links an User to an Group.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="groupid">Group id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectUserToGroup(int userid, int groupid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_user_to_group(loginReturn.client, loginReturn.sessionkey, userid, groupid);

            return result;
        }

        /// <summary>
        /// Links an Users list to a Group (Cohort).
        /// </summary>
        /// <param name="userids">Users Ids.</param>
        /// <param name="useridfield">Users id field.</param>
        /// <param name="cohortid">Cohort id.</param>
        /// <param name="cohortidfield">Cohort id field.</param>
        /// <returns>Array of <seealso cref="enrolRecord"/>.</returns>
        [WebMethod]
        public enrolRecord[] AffectUsersToCohort(string[] userids, string useridfield, string cohortid, string cohortidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            enrolRecord[] result = owsMoodle.affect_users_to_cohort(loginReturn.client, loginReturn.sessionkey, userids, useridfield, cohortid, cohortidfield);

            return result;
        }

        /// <summary>
        /// Links an Users list to a Group.
        /// </summary>
        /// <param name="userids">Users Ids.</param>
        /// <param name="useridfield">Users id field.</param>
        /// <param name="groupid">Group id.</param>
        /// <param name="groupidfield">Group id field.</param>
        /// <returns>Array of <seealso cref="enrolRecord"/>.</returns>
        [WebMethod]
        public enrolRecord[] AffectUsersToGroup(string[] userids, string useridfield, string groupid, string groupidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            enrolRecord[] result = owsMoodle.affect_users_to_group(loginReturn.client, loginReturn.sessionkey, userids, useridfield, groupid, groupidfield);

            return result;
        }

        /// <summary>
        /// Links a Wiki to a Section.
        /// </summary>
        /// <param name="wikiid">Wiki id.</param>
        /// <param name="sectionid">Section id.</param>
        /// <param name="groupmode">Group mode.</param>
        /// <param name="visible">Invisible = 0; visible = 1.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord AffectWikiToSection(int wikiid, int sectionid, int groupmode, int visible)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.affect_wiki_to_section(loginReturn.client, loginReturn.sessionkey, wikiid, sectionid, groupmode, visible);

            return result;
        }

        /// <summary>
        /// Returns the number of Activities of an User given the Course.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <param name="limit">Activities limit.</param>
        /// <returns>User activities count.</returns>
        [WebMethod]
        public int CountActivities(string userid, string useridfield, string courseid, string courseidfield, int limit)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            int result = owsMoodle.count_activities(loginReturn.client, loginReturn.sessionkey, userid, useridfield, courseid, courseidfield, limit);

            return result;
        }

        /// <summary>
        /// Returns the total of Users in a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <param name="roleid">Role id.</param>
        /// <returns>Total of Users.</returns>
        [WebMethod]
        public int CountUsersByCourse(string courseid, string idfield, int roleid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            int result = owsMoodle.count_users_bycourse(loginReturn.client, loginReturn.sessionkey, courseid, idfield, roleid);

            return result;
        }

        /// <summary>
        /// Deletes a Group (Cohort).
        /// </summary>
        /// <param name="cohortid">Cohort id.</param>
        /// <param name="cohortidfield">Cohort id field.</param>
        /// <returns>Array of <seealso cref="cohortRecord"/>.</returns>
        [WebMethod]
        public cohortRecord[] DeleteCohort(string cohortid, string cohortidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            cohortRecord[] result = owsMoodle.delete_cohort(loginReturn.client, loginReturn.sessionkey, cohortid, cohortidfield);

            return result;
        }

        /// <summary>
        /// Deletes a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] DeleteCourse(string courseid, string courseidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.delete_course(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield);

            return result;
        }

        /// <summary>
        /// Deletes a Group.
        /// </summary>
        /// <param name="groupid">Group id.</param>
        /// <param name="groupidfield">Group id field.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] DeleteGroup(string groupid, string groupidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.delete_group(loginReturn.client, loginReturn.sessionkey, groupid, groupidfield);

            return result;
        }

        /// <summary>
        /// Deletes a Grouping.
        /// </summary>
        /// <param name="groupingid">Grouping id.</param>
        /// <param name="groupingidfield">Grouping id field.</param>
        /// <returns>Array of <seealso cref="groupingRecord"/>.</returns>
        [WebMethod]
        public groupingRecord[] DeleteGrouping(string groupingid, string groupingidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupingRecord[] result = owsMoodle.delete_grouping(loginReturn.client, loginReturn.sessionkey, groupingid, groupingidfield);

            return result;
        }

        /// <summary>
        /// Deletes an User.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] DeleteUser(string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.delete_user(loginReturn.client, loginReturn.sessionkey, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Edits an array of Assignments.
        /// </summary>
        /// <param name="assignments">Array of <seealso cref="assignmentDatum"/>.</param>
        /// <returns>Array of <seealso cref="assignmentRecord"/>.</returns>
        [WebMethod]
        public assignmentRecord[] EditAssignments(assignmentDatum[] assignments)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            assignmentRecord[] result = owsMoodle.edit_assignments(loginReturn.client, loginReturn.sessionkey, assignments);

            return result;
        }

        /// <summary>
        /// Edits an array of Categories.
        /// </summary>
        /// <param name="categories">Array of <seealso cref="categoryDatum"/>.</param>
        /// <returns>Array of <seealso cref="categoryRecord"/>.</returns>
        [WebMethod]
        public categoryRecord[] EditCategories(categoryDatum[] categories)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            categoryRecord[] result = owsMoodle.edit_categories(loginReturn.client, loginReturn.sessionkey, categories);

            return result;
        }

        /// <summary>
        /// Edits an array of Courses.
        /// </summary>
        /// <param name="courses">Array of <seealso cref="courseDatum"/>.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] EditCourses(courseDatum[] courses)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.edit_courses(loginReturn.client, loginReturn.sessionkey, courses);

            return result;
        }

        /// <summary>
        /// Edits an array of Databases.
        /// </summary>
        /// <param name="databases">Array of <seealso cref="databaseDatum"/>.</param>
        /// <returns>Array of <seealso cref="databaseRecord"/>.</returns>
        [WebMethod]
        public databaseRecord[] EditDatabases(databaseDatum[] databases)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            databaseRecord[] result = owsMoodle.edit_databases(loginReturn.client, loginReturn.sessionkey, databases);

            return result;
        }

        /// <summary>
        /// Edits an array of Foruns.
        /// </summary>
        /// <param name="forums">Array of <seealso cref="forumDatum"/>.</param>
        /// <returns>Array of <seealso cref="forumRecord"/>.</returns>
        [WebMethod]
        public forumRecord[] EditForums(forumDatum[] forums)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            forumRecord[] result = owsMoodle.edit_forums(loginReturn.client, loginReturn.sessionkey, forums);

            return result;
        }

        /// <summary>
        /// Edits an array of Grouping.
        /// </summary>
        /// <param name="groupings">Array of <seealso cref="groupingDatum"/>.</param>
        /// <returns>Array of <seealso cref="groupingRecord"/>.</returns>
        [WebMethod]
        public groupingRecord[] EditGroupings(groupingDatum[] groupings)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupingRecord[] result = owsMoodle.edit_groupings(loginReturn.client, loginReturn.sessionkey, groupings);

            return result;
        }

        /// <summary>
        /// Edits an array of Group.
        /// </summary>
        /// <param name="groups">Array of <seealso cref="groupDatum"/>.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] EditGroups(groupDatum[] groups)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.edit_groups(loginReturn.client, loginReturn.sessionkey, groups);

            return result;
        }

        /// <summary>
        /// Edits an array of Labels.
        /// </summary>
        /// <param name="labels">Array of <seealso cref="labelDatum"/>.</param>
        /// <returns>Array of <seealso cref="labelRecord"/>.</returns>
        [WebMethod]
        public labelRecord[] EditLabels(labelDatum[] labels)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            labelRecord[] result = owsMoodle.edit_labels(loginReturn.client, loginReturn.sessionkey, labels);

            return result;
        }

        /// <summary>
        /// Edits an array of Wiki pages.
        /// </summary>
        /// <param name="pagesWiki">Array of <seealso cref="pageWikiDatum"/>.</param>
        /// <returns>Array of <seealso cref="pageWikiRecord"/>.</returns>
        [WebMethod]
        public pageWikiRecord[] EditPagesWiki(pageWikiDatum[] pagesWiki)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            pageWikiRecord[] result = owsMoodle.edit_pagesWiki(loginReturn.client, loginReturn.sessionkey, pagesWiki);

            return result;
        }

        /// <summary>
        /// Edits an array of Section.
        /// </summary>
        /// <param name="sections">Array of <seealso cref="sectionDatum"/>.</param>
        /// <returns>Array of <seealso cref="sectionRecord"/>.</returns>
        [WebMethod]
        public sectionRecord[] EditSections(sectionDatum[] sections)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            sectionRecord[] result = owsMoodle.edit_sections(loginReturn.client, loginReturn.sessionkey, sections);

            return result;
        }

        /// <summary>
        /// Edits an array of User.
        /// </summary>
        /// <param name="users">Array of <seealso cref="userDatum"/>.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] EditUsers(userDatum[] users)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.edit_users(loginReturn.client, loginReturn.sessionkey, users);

            return result;
        }

        /// <summary>
        /// Edits an array of Wikis.
        /// </summary>
        /// <param name="wikis">Array of <seealso cref="wikiDatum"/>.</param>
        /// <returns>Array of <seealso cref="wikiRecord"/>.</returns>
        [WebMethod]
        public wikiRecord[] EditWikis(wikiDatum[] wikis)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            wikiRecord[] result = owsMoodle.edit_wikis(loginReturn.client, loginReturn.sessionkey, wikis);

            return result;
        }

        /// <summary>
        /// Enrolls a list of students in a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <param name="userids">User ids.</param>
        /// <param name="idfield">User id field.</param>
        /// <returns>Array of <seealso cref="enrolRecord"/>.</returns>
        [WebMethod]
        public enrolRecord[] EnrolStudents(string courseid, string courseidfield, string[] userids, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            enrolRecord[] result = owsMoodle.enrol_students(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield, userids, idfield);

            return result;
        }

        /// <summary>
        /// Adds a discussion to a Forum.
        /// </summary>
        /// <param name="forumid">Forum id.</param>
        /// <param name="discussion">Object <seealso cref="forumDiscussionDatum"/>.</param>
        /// <returns>Array of <seealso cref="forumDiscussionRecord"/>.</returns>
        [WebMethod]
        public forumDiscussionRecord[] ForumAddDiscussion(int forumid, forumDiscussionDatum discussion)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            forumDiscussionRecord[] result = owsMoodle.forum_add_discussion(loginReturn.client, loginReturn.sessionkey, forumid, discussion);

            return result;
        }

        /// <summary>
        /// Adds an Answer to a Forum.
        /// </summary>
        /// <param name="parentid">Parent id.</param>
        /// <param name="post">Object <seealso cref="forumPostDatum"/>.</param>
        /// <returns>Array of <seealso cref="forumPostRecord"/>.</returns>
        [WebMethod]
        public forumPostRecord[] ForumAddReply(int parentid, forumPostDatum post)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            forumPostRecord[] result = owsMoodle.forum_add_reply(loginReturn.client, loginReturn.sessionkey, parentid, post);

            return result;
        }

        /// <summary>
        /// Returns a list of Activities of an User in a Course.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <param name="limit">Limit.</param>
        /// <returns>Array of <seealso cref="activityRecord"/>.</returns>
        [WebMethod]
        public activityRecord[] GetActivities(string userid, string useridfield, string courseid, string courseidfield, int limit)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            activityRecord[] result = owsMoodle.get_activities(loginReturn.client, loginReturn.sessionkey, userid, useridfield, courseid, courseidfield, limit);

            return result;
        }

        /// <summary>
        /// Returns a list with all Assigntments.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="assignmentRecord"/>.</returns>
        [WebMethod]
        public assignmentRecord[] GetAllAssignments(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            assignmentRecord[] result = owsMoodle.get_all_assignments(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Groups (Cohorts).
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="cohortRecord"/>.</returns>
        [WebMethod]
        public cohortRecord[] GetAllCohorts(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            cohortRecord[] result = owsMoodle.get_all_cohorts(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Databases.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="databaseRecord"/>.</returns>
        [WebMethod]
        public databaseRecord[] GetAllDatabases(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            databaseRecord[] result = owsMoodle.get_all_databases(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Forums.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="forumRecord"/>.</returns>
        [WebMethod]
        public forumRecord[] GetAllForums(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            forumRecord[] result = owsMoodle.get_all_forums(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Groupings.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="groupingRecord"/>.</returns>
        [WebMethod]
        public groupingRecord[] GetAllGroupings(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupingRecord[] result = owsMoodle.get_all_groupings(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Groups.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] GetAllGroups(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.get_all_groups(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Labels.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="labelRecord"/>.</returns>
        [WebMethod]
        public labelRecord[] GetAllLabels(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            labelRecord[] result = owsMoodle.get_all_labels(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Wiki pages.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="pageWikiRecord"/>.</returns>
        [WebMethod]
        public pageWikiRecord[] GetAllPagesWiki(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            pageWikiRecord[] result = owsMoodle.get_all_pagesWiki(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Quizzes.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="quizRecord"/>.</returns>
        [WebMethod]
        public quizRecord[] GetAllQuizzes(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            quizRecord[] result = owsMoodle.get_all_quizzes(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list with all Wikis.
        /// </summary>
        /// <param name="fieldname">Field name.</param>
        /// <param name="fieldvalue">Field value.</param>
        /// <returns>Array of <seealso cref="wikiRecord"/>.</returns>
        [WebMethod]
        public wikiRecord[] GetAllWikis(string fieldname, string fieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            wikiRecord[] result = owsMoodle.get_all_wikis(loginReturn.client, loginReturn.sessionkey, fieldname, fieldvalue);

            return result;
        }

        /// <summary>
        /// Returns a list of Assignment submissions.
        /// </summary>
        /// <param name="assignmentid">Assignment id.</param>
        /// <param name="userids">Users ids.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="timemodified">Time modified.</param>
        /// <param name="zipfiles">Number of zip files.</param>
        /// <returns>Array of <seealso cref="assignmentSubmissionRecord"/>.</returns>
        [WebMethod]
        public assignmentSubmissionRecord[] GetAssignmentSubmissions(int assignmentid, string[] userids, string useridfield, int timemodified, int zipfiles)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            assignmentSubmissionRecord[] result = owsMoodle.get_assignment_submissions(loginReturn.client, loginReturn.sessionkey, assignmentid, userids, useridfield, timemodified, zipfiles);

            return result;
        }

        /// <summary>
        /// Returns an array with all Categories.
        /// </summary>
        /// <param name="catid">Category id.</param>
        /// <param name="idfield">Category id field.</param>
        /// <returns>Array of <seealso cref="categoryRecord"/>.</returns>
        [WebMethod]
        public categoryRecord[] GetCategories(string catid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            categoryRecord[] result = owsMoodle.get_categories(loginReturn.client, loginReturn.sessionkey, catid, idfield);

            return result;
        }

        /// <summary>
        /// Returns a Category given its Id.
        /// </summary>
        /// <param name="catid">Category id.</param>
        /// <returns>Array of <seealso cref="categoryRecord"/>.</returns>
        [WebMethod]
        public categoryRecord[] GetCategoryById(string catid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            categoryRecord[] result = owsMoodle.get_category_byid(loginReturn.client, loginReturn.sessionkey, catid);

            return result;
        }

        /// <summary>
        /// Returns a Category given its name.
        /// </summary>
        /// <param name="catname">Category name.</param>
        /// <returns>Array of <seealso cref="categoryRecord"/>.</returns>
        [WebMethod]
        public categoryRecord[] GetCategoryByName(string catname)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            categoryRecord[] result = owsMoodle.get_category_byname(loginReturn.client, loginReturn.sessionkey, catname);

            return result;
        }

        /// <summary>
        /// Returns a Group (Cohort) given its Id.
        /// </summary>
        /// <param name="groupid">Group id.</param>
        /// <returns>Array of <seealso cref="cohortRecord"/>.</returns>
        [WebMethod]
        public cohortRecord[] GetCohortById(int groupid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            cohortRecord[] result = owsMoodle.get_cohort_byid(loginReturn.client, loginReturn.sessionkey, groupid);

            return result;
        }

        /// <summary>
        /// Returns a Group (Cohort) given its Id.
        /// </summary>
        /// <param name="cohortidnumber">Cohort number.</param>
        /// <returns>Array of <seealso cref="cohortRecord"/>.</returns>
        [WebMethod]
        public cohortRecord[] GetCohortByIdNumber(string cohortidnumber)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            cohortRecord[] result = owsMoodle.get_cohort_byidnumber(loginReturn.client, loginReturn.sessionkey, cohortidnumber);

            return result;
        }

        /// <summary>
        /// Returns a list of members in a Group (Cohort).
        /// </summary>
        /// <param name="id">Group id.</param>
        /// <param name="idfield">Group id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetCohortMembers(string id, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_cohort_members(loginReturn.client, loginReturn.sessionkey, id, idfield);

            return result;
        }

        /// <summary>
        /// Returns  a Group (Cohort) given its name.
        /// </summary>
        /// <param name="cohortname">Cohort name.</param>
        /// <returns>Array of <seealso cref="cohortRecord"/>.</returns>
        [WebMethod]
        public cohortRecord[] GetCohortsByName(string cohortname)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            cohortRecord[] result = owsMoodle.get_cohorts_byname(loginReturn.client, loginReturn.sessionkey, cohortname);

            return result;
        }

        /// <summary>
        /// Returns a Course given its Id.
        /// </summary>
        /// <param name="info">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetCourse(string info, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_course(loginReturn.client, loginReturn.sessionkey, info, idfield);

            return result;
        }

        /// <summary>
        /// Returns a Course given its Id.
        /// </summary>
        /// <param name="info">Course id.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetCourseById(string info)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_course_byid(loginReturn.client, loginReturn.sessionkey, info);

            return result;
        }

        /// <summary>
        /// Returns a Course given its Id.
        /// </summary>
        /// <param name="info">Course id.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetCourseByIdNumber(string info)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_course_byidnumber(loginReturn.client, loginReturn.sessionkey, info);

            return result;
        }

        /// <summary>
        /// Returns the Grades of a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="gradeRecord"/>.</returns>
        [WebMethod]
        public gradeRecord[] GetCourseGrades(string courseid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            gradeRecord[] result = owsMoodle.get_course_grades(loginReturn.client, loginReturn.sessionkey, courseid, idfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Courses given their IDs.
        /// </summary>
        /// <param name="courseids">Courses Ids.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetCourses(string[] courseids, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_courses(loginReturn.client, loginReturn.sessionkey, courseids, idfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Courses given their Category.
        /// </summary>
        /// <param name="catid">Category id.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetCoursesByCategory(string catid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_courses_bycategory(loginReturn.client, loginReturn.sessionkey, catid);

            return result;
        }

        /// <summary>
        /// Returns a list for Courses that contain the search expression.
        /// </summary>
        /// <param name="search">Search expression.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetCoursesSearch(string search)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_courses_search(loginReturn.client, loginReturn.sessionkey, search);

            return result;
        }

        /// <summary>
        /// Returns a list of Events.
        /// </summary>
        /// <param name="eventtype">Event type.</param>
        /// <param name="ownerid">Owner id.</param>
        /// <param name="owneridfield">Owner id field.</param>
        /// <param name="datetimefrom">Date and time from.</param>
        /// <returns>Array of <seealso cref="eventRecord"/>.</returns>
        [WebMethod]
        public eventRecord[] GetEvents(int eventtype, string ownerid, string owneridfield, int datetimefrom)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            eventRecord[] result = owsMoodle.get_events(loginReturn.client, loginReturn.sessionkey, eventtype, ownerid, owneridfield, datetimefrom);

            return result;
        }

        /// <summary>
        /// Returns a list of discussions in a Forum.
        /// </summary>
        /// <param name="forumid">Forum id.</param>
        /// <param name="limit">Limit.</param>
        /// <returns>Array of <seealso cref="forumDiscussionRecord"/>.</returns>
        [WebMethod]
        public forumDiscussionRecord[] GetForumDiscussions(int forumid, int limit)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            forumDiscussionRecord[] result = owsMoodle.get_forum_discussions(loginReturn.client, loginReturn.sessionkey, forumid, limit);

            return result;
        }

        /// <summary>
        /// Returns a list of posts in a Forum.
        /// </summary>
        /// <param name="discussionid">Discussion id.</param>
        /// <param name="limit">Limit.</param>
        /// <returns>Array of <seealso cref="forumPostRecord"/>.</returns>
        [WebMethod]
        public forumPostRecord[] GetForumPosts(int discussionid, int limit)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            forumPostRecord[] result = owsMoodle.get_forum_posts(loginReturn.client, loginReturn.sessionkey, discussionid, limit);

            return result;
        }

        /// <summary>
        /// Returns a list of Grades.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="courseids">Courses ids.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <returns>Array of <seealso cref="gradeRecord"/>.</returns>
        [WebMethod]
        public gradeRecord[] GetGrades(string userid, string useridfield, string[] courseids, string courseidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            gradeRecord[] result = owsMoodle.get_grades(loginReturn.client, loginReturn.sessionkey, userid, useridfield, courseids, courseidfield);

            return result;
        }

        /// <summary>
        /// Returns a Group given its Id.
        /// </summary>
        /// <param name="groupid">Group id.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] GetGroupById(int groupid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.get_group_byid(loginReturn.client, loginReturn.sessionkey, groupid);

            return result;
        }

        /// <summary>
        /// Returns a list of members in a Group.
        /// </summary>
        /// <param name="groupid">Group id.</param>
        /// <param name="groupidfield">Group id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetGroupMembers(string groupid, string groupidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_group_members(loginReturn.client, loginReturn.sessionkey, groupid, groupidfield);

            return result;
        }

        /// <summary>
        /// Returns a Grouping given a Group.
        /// </summary>
        /// <param name="groupid">Group id.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] GetGroupingById(int groupid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.get_grouping_byid(loginReturn.client, loginReturn.sessionkey, groupid);

            return result;
        }

        /// <summary>
        /// Returns a list of members given a Group.
        /// </summary>
        /// <param name="groupid">Group id.</param>
        /// <param name="groupidfield">Group id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetGroupingMembers(string groupid, string groupidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_grouping_members(loginReturn.client, loginReturn.sessionkey, groupid, groupidfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Grouping by Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="groupingRecord"/>.</returns>
        [WebMethod]
        public groupingRecord[] GetGroupingsByCourse(string courseid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupingRecord[] result = owsMoodle.get_groupings_bycourse(loginReturn.client, loginReturn.sessionkey, courseid, idfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Groupings by name.
        /// </summary>
        /// <param name="groupname">Grouping name.</param>
        /// <param name="courseid">Course id.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] GetGroupingsByName(string groupname, int courseid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.get_groupings_byname(loginReturn.client, loginReturn.sessionkey, groupname, courseid);

            return result;
        }

        /// <summary>
        /// Returns a list of Groups by Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] GetGroupsByCourse(string courseid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.get_groups_bycourse(loginReturn.client, loginReturn.sessionkey, courseid, idfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Groups by nome.
        /// </summary>
        /// <param name="groupname">Group name.</param>
        /// <param name="courseid">Course id.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] GetGroupsByName(string groupname, int courseid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.get_groups_byname(loginReturn.client, loginReturn.sessionkey, groupname, courseid);

            return result;
        }

        /// <summary>
        /// Returns a list of Instances by Type.
        /// </summary>
        /// <param name="courseids">Courses ids.</param>
        /// <param name="idfield">Course id field.</param>
        /// <param name="type">Type.</param>
        /// <returns>Array of <seealso cref="resourceRecord"/>.</returns>
        [WebMethod]
        public resourceRecord[] GetInstancesByType(string[] courseids, string idfield, string type)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            resourceRecord[] result = owsMoodle.get_instances_bytype(loginReturn.client, loginReturn.sessionkey, courseids, idfield, type);

            return result;
        }

        /// <summary>
        /// Returns the last changes in a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <param name="limit">Limit.</param>
        /// <returns>Array of <seealso cref="changeRecord"/>.</returns>
        [WebMethod]
        public changeRecord[] GetLastChanges(string courseid, string idfield, int limit)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            changeRecord[] result = owsMoodle.get_last_changes(loginReturn.client, loginReturn.sessionkey, courseid, idfield, limit);

            return result;
        }

        /// <summary>
        /// Returns a list of Contacts in a Message.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <returns>Array of <seealso cref="contactRecord"/>.</returns>
        [WebMethod]
        public contactRecord[] GetMessageContacts(string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            contactRecord[] result = owsMoodle.get_message_contacts(loginReturn.client, loginReturn.sessionkey, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Returns a list of User's messages.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <returns>Array of <seealso cref="messageRecord"/>.</returns>
        [WebMethod]
        public messageRecord[] GetMessages(string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            messageRecord[] result = owsMoodle.get_messages(loginReturn.client, loginReturn.sessionkey, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Returns the historic of messages between two users.
        /// </summary>
        /// <param name="useridto">User id "to".</param>
        /// <param name="useridtofield">User id "to" field.</param>
        /// <param name="useridfrom">User id "from".</param>
        /// <param name="useridfromfield">User id "from" field.</param>
        /// <returns>Array of <seealso cref="messageRecord"/>.</returns>
        [WebMethod]
        public messageRecord[] GetMessagesHistory(string useridto, string useridtofield, string useridfrom, string useridfromfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            messageRecord[] result = owsMoodle.get_messages_history(loginReturn.client, loginReturn.sessionkey, useridto, useridtofield, useridfrom, useridfromfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Grades in a Module.
        /// </summary>
        /// <param name="activityid">Activity id.</param>
        /// <param name="activitytype">Activity type.</param>
        /// <param name="userids">User ids.</param>
        /// <param name="useridfield">User id field.</param>
        /// <returns>Array of <seealso cref="gradeItemRecord"/>.</returns>
        [WebMethod]
        public gradeItemRecord[] GetModuleGrades(int activityid, string activitytype, string[] userids, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            gradeItemRecord[] result = owsMoodle.get_module_grades(loginReturn.client, loginReturn.sessionkey, activityid, activitytype, userids, useridfield);

            return result;
        }

        /// <summary>
        /// Returns the Grades given an Assignement.
        /// </summary>
        /// <param name="assignmentid">Assignment id.</param>
        /// <returns>Array of <seealso cref="gradeItemRecord"/>.</returns>
        [WebMethod]
        public gradeItemRecord[] GetMyAssignmentGrade(int assignmentid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            gradeItemRecord[] result = owsMoodle.get_my_assignment_grade(loginReturn.client, loginReturn.sessionkey, assignmentid);

            return result;
        }

        /// <summary>
        /// Returns a list of Groups (Cohorts) given an User.
        /// </summary>
        /// <param name="uid">User id.</param>
        /// <param name="idfield">User id field.</param>
        /// <returns>Array of <seealso cref="cohortRecord"/>.</returns>
        [WebMethod]
        public cohortRecord[] GetMyCohorts(string uid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            cohortRecord[] result = owsMoodle.get_my_cohorts(loginReturn.client, loginReturn.sessionkey, uid, idfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Courses given an User.
        /// </summary>
        /// <param name="uid">User id.</param>
        /// <param name="sort">Sort column.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetMyCourses(string uid, string sort)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_my_courses(loginReturn.client, loginReturn.sessionkey, uid, sort);

            return result;
        }

        /// <summary>
        /// Returns a list of Courses given an User.
        /// </summary>
        /// <param name="uid">User id.</param>
        /// <param name="sort">Sort column.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetMyCoursesByIdNumber(string uid, string sort)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_my_courses_byidnumber(loginReturn.client, loginReturn.sessionkey, uid, sort);

            return result;
        }

        /// <summary>
        /// Returns a list of Courses given an User.
        /// </summary>
        /// <param name="uid">User name.</param>
        /// <param name="sort">Sort column.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] GetMyCoursesByUserName(string uid, string sort)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.get_my_courses_byusername(loginReturn.client, loginReturn.sessionkey, uid, sort);

            return result;
        }

        /// <summary>
        /// Returns an User's Group given a Course.
        /// </summary>
        /// <param name="uid">User id.</param>
        /// <param name="idfield">User id field.</param>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] GetMyGroup(int uid, int idfield, string courseid, string courseidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.get_my_group(loginReturn.client, loginReturn.sessionkey, uid, idfield, courseid, courseidfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Groups that the User belongs.
        /// </summary>
        /// <param name="uid">User id.</param>
        /// <param name="idfield">User id field.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] GetMyGroups(string uid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.get_my_groups(loginReturn.client, loginReturn.sessionkey, uid, idfield);

            return result;
        }

        /// <summary>
        /// Returns the webservice default user's id.
        /// </summary>
        /// <returns>User id.</returns>
        [WebMethod]
        public int GetMyId()
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();

            return owsMoodle.get_my_id(loginReturn.client, loginReturn.sessionkey);
        }

        /// <summary>
        /// Returns a list of Grades in a Module given an Activity.
        /// </summary>
        /// <param name="activityid">Activity id.</param>
        /// <param name="activitytype">Activity type.</param>
        /// <returns>Array of <seealso cref="gradeItemRecord"/>.</returns>
        [WebMethod]
        public gradeItemRecord[] GetMyModuleGrade(int activityid, string activitytype)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            gradeItemRecord[] result = owsMoodle.get_my_module_grade(loginReturn.client, loginReturn.sessionkey, activityid, activitytype);

            return result;
        }

        /// <summary>
        /// Returns a list of Quizzes Grades to the current User.
        /// </summary>
        /// <param name="quizid">Quiz id.</param>
        /// <returns>Array of <seealso cref="gradeItemRecord"/>.</returns>
        [WebMethod]
        public gradeItemRecord[] GetMyQuizGrade(int quizid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            gradeItemRecord[] result = owsMoodle.get_my_quiz_grade(loginReturn.client, loginReturn.sessionkey, quizid);

            return result;
        }

        /// <summary>
        /// Returns o primary Role of an User in a Course.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <returns>Primary Role id.</returns>
        [WebMethod]
        public int GetPrimaryRoleInCourse(string userid, string useridfield, string courseid, string courseidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();

            return owsMoodle.get_primaryrole_incourse(loginReturn.client, loginReturn.sessionkey, userid, useridfield, courseid, courseidfield);
        }

        /// <summary>
        /// Returns a Quiz.
        /// </summary>
        /// <param name="quizid">Quiz id.</param>
        /// <param name="format">Quiz format.</param>
        /// <returns>Object <seealso cref="quizRecord"/>.</returns>
        [WebMethod]
        public quizRecord GetQuiz(int quizid, string format)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            quizRecord result = owsMoodle.get_quiz(loginReturn.client, loginReturn.sessionkey, quizid, format);

            return result;
        }

        /// <summary>
        /// Returns a Resource.
        /// </summary>
        /// <param name="resourceid">Resource id.</param>
        /// <returns>Object <seealso cref="fileRecord"/>.</returns>
        [WebMethod]
        public fileRecord GetResourceFileById(int resourceid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            fileRecord result = owsMoodle.get_resourcefile_byid(loginReturn.client, loginReturn.sessionkey, resourceid);

            return result;
        }

        /// <summary>
        /// Returns the Resources of a Course list.
        /// </summary>
        /// <param name="courseids">Courses ids.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="resourceRecord"/>.</returns>
        [WebMethod]
        public resourceRecord[] GetResources(string[] courseids, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            resourceRecord[] result = owsMoodle.get_resources(loginReturn.client, loginReturn.sessionkey, courseids, idfield);

            return result;
        }

        /// <summary>
        /// Returns a Role given its Id.
        /// </summary>
        /// <param name="roleid">Role id.</param>
        /// <returns>Array of <seealso cref="roleRecord"/>.</returns>
        [WebMethod]
        public roleRecord[] GetRoleById(int roleid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            roleRecord[] result = owsMoodle.get_role_byid(loginReturn.client, loginReturn.sessionkey, roleid);

            return result;
        }

        /// <summary>
        /// Returns a Role given its name.
        /// </summary>
        /// <param name="rolename">Role name.</param>
        /// <returns>Array of <seealso cref="roleRecord"/>.</returns>
        [WebMethod]
        public roleRecord[] GetRoleByName(string rolename)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            roleRecord[] result = owsMoodle.get_role_byname(loginReturn.client, loginReturn.sessionkey, rolename);

            return result;
        }

        /// <summary>
        /// Returns a list of Roles given any of its attributes.
        /// </summary>
        /// <param name="roleid">Role id.</param>
        /// <param name="roleidfield">Role id field.</param>
        /// <returns>Array of <seealso cref="roleRecord"/>.</returns>
        [WebMethod]
        public roleRecord[] GetRoles(string roleid, string roleidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            roleRecord[] result = owsMoodle.get_roles(loginReturn.client, loginReturn.sessionkey, roleid, roleidfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Sections given a list of Courses.
        /// </summary>
        /// <param name="courseids">Courses ids.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="sectionRecord"/>.</returns>
        [WebMethod]
        public sectionRecord[] GetSections(string[] courseids, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            sectionRecord[] result = owsMoodle.get_sections(loginReturn.client, loginReturn.sessionkey, courseids, idfield);

            return result;
        }

        /// <summary>
        /// Returns the students in a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetStudents(string courseid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_students(loginReturn.client, loginReturn.sessionkey, courseid, idfield);

            return result;
        }

        /// <summary>
        /// Returns the teachers in a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetTeachers(string courseid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_teachers(loginReturn.client, loginReturn.sessionkey, courseid, idfield);

            return result;
        }

        /// <summary>
        /// Returns the Users that match the search criteria.
        /// </summary>
        /// <param name="userinfo">User id.</param>
        /// <param name="idfield">User id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetUser(string userinfo, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_user(loginReturn.client, loginReturn.sessionkey, userinfo, idfield);

            return result;
        }

        /// <summary>
        /// Returns an User given its Id.
        /// </summary>
        /// <param name="userinfo">User id.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetUserById(int userinfo)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_user_byid(loginReturn.client, loginReturn.sessionkey, userinfo);

            return result;
        }

        /// <summary>
        /// Returns an User given any attribute.
        /// </summary>
        /// <param name="userinfo">User info.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetUserByIdNumber(string userinfo)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_user_byidnumber(loginReturn.client, loginReturn.sessionkey, userinfo);

            return result;
        }

        /// <summary>
        /// Returns an User given its name.
        /// </summary>
        /// <param name="userinfo">User name.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetUserByUserName(string userinfo)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_user_byusername(loginReturn.client, loginReturn.sessionkey, userinfo);

            return result;
        }

        /// <summary>
        /// Returns a list of Grades given an User.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="idfield">User id field.</param>
        /// <returns>Array of <seealso cref="gradeRecord"/>.</returns>
        [WebMethod]
        public gradeRecord[] GetUserGrades(string userid, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            gradeRecord[] result = owsMoodle.get_user_grades(loginReturn.client, loginReturn.sessionkey, userid, idfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Users given their Ids.
        /// </summary>
        /// <param name="userids">Users ids.</param>
        /// <param name="idfield">User id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetUsers(string[] userids, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_users(loginReturn.client, loginReturn.sessionkey, userids, idfield);

            return result;
        }

        /// <summary>
        /// Returns a list of Users by Course.
        /// </summary>
        /// <param name="idcourse">Course id.</param>
        /// <param name="idfield">Course id field.</param>
        /// <param name="idrole">Role id.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetUsersByCourse(string idcourse, string idfield, int idrole)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_users_bycourse(loginReturn.client, loginReturn.sessionkey, idcourse, idfield, idrole);

            return result;
        }

        /// <summary>
        /// Returns a list of Users by Profile.
        /// </summary>
        /// <param name="profilefieldname">Profile field name.</param>
        /// <param name="profilefieldvalue">Profile field value.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] GetUsersByProfile(string profilefieldname, string profilefieldvalue)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.get_users_byprofile(loginReturn.client, loginReturn.sessionkey, profilefieldname, profilefieldvalue);

            return result;
        }

        /// <summary>
        /// Returns the Moodle version.
        /// </summary>
        /// <returns>Moodle version.</returns>
        [WebMethod]
        public int GetVersion()
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();

            return owsMoodle.get_version(loginReturn.client, loginReturn.sessionkey);
        }

        /// <summary>
        /// Returns true or false if exists Roles for an User in a Course.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <param name="roleid">Role id.</param>
        /// <returns>True, if the User has a Role in the Course; false instead.</returns>
        [WebMethod]
        public bool HasRoleInCourse(string userid, string useridfield, string courseid, string courseidfield, int roleid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();

            return owsMoodle.has_role_incourse(loginReturn.client, loginReturn.sessionkey, userid, useridfield, courseid, courseidfield, roleid);
        }

        /// <summary>
        /// Send a Message to an User.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="message">Message.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord MessageSend(string userid, string useridfield, string message)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.message_send(loginReturn.client, loginReturn.sessionkey, userid, useridfield, message);

            return result;
        }

        /// <summary>
        /// Deletes a Group from a Grouping.
        /// </summary>
        /// <param name="groupid">Group id.</param>
        /// <param name="groupingid">Grouping id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord RemoveGroupFromGrouping(int groupid, int groupingid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.remove_group_from_grouping(loginReturn.client, loginReturn.sessionkey, groupid, groupingid);

            return result;
        }

        /// <summary>
        /// Deletes a Teacher from a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord RemoveNonEditingTeacher(string courseid, string courseidfield, string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.remove_noneditingteacher(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Deletes a student from a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord RemoveStudent(string courseid, string courseidfield, string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.remove_student(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Deletes a Teacher from a Course.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord RemoveTeacher(string courseid, string courseidfield, string userid, string useridfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.remove_teacher(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield, userid, useridfield);

            return result;
        }

        /// <summary>
        /// Deletes an User from a Cohort.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="groupid">Group id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord RemoveUserFromCohort(int userid, int groupid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.remove_user_from_cohort(loginReturn.client, loginReturn.sessionkey, userid, groupid);

            return result;
        }

        /// <summary>
        /// Deletes an User from a Course.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="courseid">Course id.</param>
        /// <param name="rolename">Role name.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord RemoveUserFromCourse(int userid, int courseid, string rolename)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.remove_user_from_course(loginReturn.client, loginReturn.sessionkey, userid, courseid, rolename);

            return result;
        }

        /// <summary>
        /// Deletes an User from a Group.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="groupid">Group id.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public affectRecord RemoveUserFromGroup(int userid, int groupid)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            affectRecord result = owsMoodle.remove_user_from_group(loginReturn.client, loginReturn.sessionkey, userid, groupid);

            return result;
        }

        /// <summary>
        /// Deletes a list of Users from a Cohort.
        /// </summary>
        /// <param name="userids">Users ids.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="cohortid">Cohort id.</param>
        /// <param name="cohortidfield">Cohort id field.</param>
        /// <returns>Object <seealso cref="affectRecord"/>.</returns>
        [WebMethod]
        public enrolRecord[] RemoveUsersFromCohort(string[] userids, string useridfield, string cohortid, string cohortidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            enrolRecord[] result = owsMoodle.remove_users_from_cohort(loginReturn.client, loginReturn.sessionkey, userids, useridfield, cohortid, cohortidfield);

            return result;
        }

        /// <summary>
        /// Deletes a list of Users from a Group.
        /// </summary>
        /// <param name="userids">Users ids.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="groupid">Group id.</param>
        /// <param name="groupidfield">Group id field.</param>
        /// <returns>Array of <seealso cref="enrolRecord"/>.</returns>
        [WebMethod]
        public enrolRecord[] RemoveUsersFromGroup(string[] userids, string useridfield, string groupid, string groupidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            enrolRecord[] result = owsMoodle.remove_users_from_group(loginReturn.client, loginReturn.sessionkey, userids, useridfield, groupid, groupidfield);

            return result;
        }

        /// <summary>
        /// Sets the User profiles.
        /// </summary>
        /// <param name="userid">User id.</param>
        /// <param name="useridfield">User id field.</param>
        /// <param name="values">Array of <seealso cref="profileitemRecord"/>.</param>
        /// <returns>Array of <seealso cref="profileitemRecord"/>.</returns>
        [WebMethod]
        public profileitemRecord[] SetUserProfileValues(string userid, string useridfield, profileitemRecord[] values)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            profileitemRecord[] result = owsMoodle.set_user_profile_values(loginReturn.client, loginReturn.sessionkey, userid, useridfield, values);

            return result;
        }

        /// <summary>
        /// Unenrol a list of Students.
        /// </summary>
        /// <param name="courseid">Course id.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <param name="userids">Users ids.</param>
        /// <param name="idfield">User id field.</param>
        /// <returns>Array of <seealso cref="enrolRecord"/>.</returns>
        [WebMethod]
        public enrolRecord[] UnenrolStudents(string courseid, string courseidfield, string[] userids, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            enrolRecord[] result = owsMoodle.unenrol_students(loginReturn.client, loginReturn.sessionkey, courseid, courseidfield, userids, idfield);

            return result;
        }

        /// <summary>
        /// Update a Group (Cohort).
        /// </summary>
        /// <param name="datum">Object <seealso cref="cohortDatum"/>.</param>
        /// <param name="idfield">Cohort id field.</param>
        /// <returns>Array of <seealso cref="cohortRecord"/>.</returns>
        [WebMethod]
        public cohortRecord[] UpdateCohort(cohortDatum datum, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            cohortRecord[] result = owsMoodle.update_cohort(loginReturn.client, loginReturn.sessionkey, datum, idfield);

            return result;
        }

        /// <summary>
        /// Update a Course.
        /// </summary>
        /// <param name="datum">Object <seealso cref="courseDatum"/>.</param>
        /// <param name="courseidfield">Course id field.</param>
        /// <returns>Array of <seealso cref="courseRecord"/>.</returns>
        [WebMethod]
        public courseRecord[] UpdateCourse(courseDatum datum, string courseidfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            courseRecord[] result = owsMoodle.update_course(loginReturn.client, loginReturn.sessionkey, datum, courseidfield);

            return result;
        }

        /// <summary>
        /// Update a Group.
        /// </summary>
        /// <param name="datum">Object <seealso cref="groupDatum"/>.</param>
        /// <param name="idfield">Group id field.</param>
        /// <returns>Array of <seealso cref="groupRecord"/>.</returns>
        [WebMethod]
        public groupRecord[] UpdateGroup(groupDatum datum, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupRecord[] result = owsMoodle.update_group(loginReturn.client, loginReturn.sessionkey, datum, idfield);

            return result;
        }

        /// <summary>
        /// Update a Grouping.
        /// </summary>
        /// <param name="datum">Object <seealso cref="groupingDatum"/>.</param>
        /// <param name="idfield">Grouping id field.</param>
        /// <returns>Array of <seealso cref="groupingRecord"/>.</returns>
        [WebMethod]
        public groupingRecord[] UpdateGrouping(groupingDatum datum, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            groupingRecord[] result = owsMoodle.update_grouping(loginReturn.client, loginReturn.sessionkey, datum, idfield);

            return result;
        }

        /// <summary>
        /// Update a Section.
        /// </summary>
        /// <param name="datum">Object <seealso cref="sectionDatum"/>.</param>
        /// <param name="idfield">Section id field.</param>
        /// <returns>Array of <seealso cref="sectionRecord"/>.</returns>
        [WebMethod]
        public sectionRecord[] UpdateSection(sectionDatum datum, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            sectionRecord[] result = owsMoodle.update_section(loginReturn.client, loginReturn.sessionkey, datum, idfield);

            return result;
        }

        /// <summary>
        /// Update an User.
        /// </summary>
        /// <param name="datum">Object <seealso cref="userDatum"/>.</param>
        /// <param name="idfield">User id field.</param>
        /// <returns>Array of <seealso cref="userRecord"/>.</returns>
        [WebMethod]
        public userRecord[] UpdateUser(userDatum datum, string idfield)
        {
            loginReturn loginReturn = this.Login();

            mdl_soapserverPortTypeClient owsMoodle = new mdl_soapserverPortTypeClient();
            userRecord[] result = owsMoodle.update_user(loginReturn.client, loginReturn.sessionkey, datum, idfield);

            return result;
        }
    }
}
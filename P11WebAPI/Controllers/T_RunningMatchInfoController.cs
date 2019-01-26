using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using P11WebAPI.P11DbModel;

namespace P11WebAPI.Controllers
{
    public class T_RunningMatchInfoController : ApiController
    {
        private P11DbEntities1 db = new P11DbEntities1();

        // GET: api/T_RunningMatchInfo
        public IQueryable<T_RunningMatchInfo> GetT_RunningMatchInfo()
        {
            return db.T_RunningMatchInfo;
        }

        // GET: api/T_RunningMatchInfo/5
        //[ResponseType(typeof(T_RunningMatchInfo))]
        public HttpResponseMessage GetT_RunningMatchInfo(int id)
        {
            T_RunningMatchInfo t_RunningMatchInfo = db.T_RunningMatchInfo.Where(x=>x.MatchID==id).FirstOrDefault();
            if(t_RunningMatchInfo==null)
            {
                t_RunningMatchInfo = new T_RunningMatchInfo();
                //t_RunningMatchInfo.MatchDescription = "<header class='entry - header' style='box - sizing: inherit; color: #222222; font-family: roboto, sans-serif; font-size: 16px;'> <h1 class='entry-title' style='box-sizing: inherit; font-size: 3.6rem; margin: 0px 0px 16px; font-family: raleway, sans-serif; font-weight: 500; line-height: 1;'>MAR vs NOR Dream11 Team Prediction: Preview</h1> <p class='entry-meta' style='box-sizing: inherit; margin: 0px 0px 30px; padding: 0px; font-size: 1.4rem;'><time class='entry-time' style='box-sizing: inherit;' datetime='2018-11-25T11:16:34+00:00'>25 November, 2018</time>&nbsp;by&nbsp;<span class='entry-author' style='box-sizing: inherit;'><a class='entry-author-link' style='box-sizing: inherit; background-color: inherit; transition: all 0.1s ease-in-out 0s; color: #222222; text-decoration-line: none;' href='https://dreamteamcric.com/author/pranobt/' rel='author'>Pranob Thachanthara</a></span>&nbsp;<span class='entry-comments-link' style='box-sizing: inherit;'><a style='box-sizing: inherit; background-color: inherit; transition: all 0.1s ease-in-out 0s; color: #222222; text-decoration-line: none;' href='https://dreamteamcric.com/mar-vs-nor-dream11-team-prediction/#respond'>Leave a Comment</a></span></p> </header> <div class='entry-content' style='box-sizing: inherit; color: #222222; font-family: roboto, sans-serif; font-size: 16px;'><img class='attachment-post-image size-post-image wp-post-image jetpack-lazy-image jetpack-lazy-image--handled' style='box-sizing: inherit; border-style: none; max-width: 100%; height: auto;' src='https://dreamteamcric.com/wp-content/uploads/MAR-vs-NOR.jpg?x89085' alt='MAR vs NOR Dream11' width='750' height='420' data-lazy-loaded='1' /> <h2 style='box-sizing: inherit; font-family: raleway, sans-serif; font-weight: 500; line-height: 1.2; margin: 0px 0px 16px; font-size: 3rem;'>MAR vs NOR Dream11 Team Prediction: Preview</h2> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>Hello and Welcome to our preview for Maratha Arabians vs Northern Warriors T10 match. We are covering<span style='box-sizing: inherit; font-weight: bold;'>MAR vs NOR&nbsp;<u style='box-sizing: inherit;'><a style='box-sizing: inherit; background-color: inherit; transition: all 0.1s ease-in-out 0s; color: #e8554e; font-weight: 400; text-decoration-line: none;' href='https://dreamteamcric.com/dream11-app-sign-up-get-100-rs/'>Dream11</a></u></span>&nbsp;Team Prediction, Preview and Probable Playing XI for the match. The match is to be played at Sharjah.</p> <div id='quads-ad1' class='quads-location quads-ad1' style='box-sizing: inherit; float: none; margin: 0px; text-align: center;'> <div class='aicp' style='box-sizing: inherit;'><ins class='adsbygoogle' style='box-sizing: inherit; display: block; height: 90px;' data-ad-client='ca-pub-3859579878880515' data-ad-slot='3541649913' data-ad-format='auto' data-adsbygoogle-status='done'><ins id='aswift_0_expand' style='box-sizing: inherit; display: inline-table; border: none; height: 90px; margin: 0px; padding: 0px; position: relative; visibility: visible; width: 750px; background-color: transparent;'><ins id='aswift_0_anchor' style='box-sizing: inherit; display: block; border: none; height: 90px; margin: 0px; padding: 0px; position: relative; visibility: visible; width: 750px; background-color: transparent;'><iframe id='aswift_0' style='box-sizing: inherit; max-width: 100%; left: 0px; position: absolute; top: 0px; width: 750px; height: 90px;' name='aswift_0' width='750' height='90' frameborder='0' marginwidth='0' marginheight='0' scrolling='no' allowfullscreen='true'></iframe></ins></ins></ins></div> </div> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>Northern Warriors have won and lost one encounter yet in the series. In the last match, They defeated Punjabi Legends by 99 runs. Batting first, Nicholas Pooran played a spectacular knock of 77 runs in just 25 balls. He was supported by Lendl Simmons and Destructive Cameos by Russell and R Powell ensured the high target of 183. Ravi Bopara starred with the ball taking four wickets to provide an easy win to the team. They will hope for a similar unison effort from all players in tomorrow&rsquo;s matches.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>Maratha Arabians won their last encounter against Bengal Tigers by nine wickets. Good performance by bowlers especially James Faulkner ensured the chaseable target of 92 runs. H Zazai starred with the bat scoring 76 runs in just 35 balls. They will hope to continue the momentum ahead.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>A good match can be expected between both teams.</p> <h2 style='box-sizing: inherit; font-family: raleway, sans-serif; font-weight: 500; line-height: 1.2; margin: 0px 0px 16px; font-size: 3rem;'>When and Where:</h2> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>MAR vs NOR, 12th Match, Group B, T10 League 2018.<br style='box-sizing: inherit;' />Sharjah Cricket Association Stadium, Sharjah.<br style='box-sizing: inherit;' />November 25th, 10:15 PM IST<span style='box-sizing: inherit; font-weight: bold;'>&nbsp;</span></p> <h2 style='box-sizing: inherit; font-family: raleway, sans-serif; font-weight: 500; line-height: 1.2; margin: 0px 0px 16px; font-size: 3rem;'>Squads:</h2> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><span style='box-sizing: inherit; font-weight: bold;'>NOR:<br style='box-sizing: inherit;' /></span>Darren Sammy (c), Andre Russell, Harry Gurnet, Chris Green, Wahab Riaz, Amitoze Singh, Hardus Viljoen, Lendl Simmons, Nicholas Pooran, Khary Pierre, Dwayne Smith, Kennar Lewis, Ravi Bopara, Imran Haider, Rahul Bhatia, Rovman Powell.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><span style='box-sizing: inherit; font-weight: bold;'>MAR:<br style='box-sizing: inherit;' /></span>Alex Hales, Kamran Akmal (wk), Najibullah Zadran, Richard Gleeson, Rashid Khan (c), James Vince, Hazratullah Zazai, Adam Lyth, Brendan Taylor, Zahoor Khan, Dwayne Bravo, James Faulkner, S Badrinath, Roelof van der Merwe, Amir Hayat.</p> <h2 style='box-sizing: inherit; font-family: raleway, sans-serif; font-weight: 500; line-height: 1.2; margin: 0px 0px 16px; font-size: 3rem;'>Team News:<span style='box-sizing: inherit; font-weight: bold;'>&nbsp;</span></h2> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><em style='box-sizing: inherit;'>Note: Every team has to play minimum one UAE player.</em></p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><span style='box-sizing: inherit; font-weight: bold;'>Maratha Arabians:</span></p> <div id='quads-ad2' class='quads-location quads-ad2' style='box-sizing: inherit; float: none; margin: 0px; text-align: center;'> <div class='aicp' style='box-sizing: inherit;'><ins class='adsbygoogle' style='box-sizing: inherit; display: inline-block; width: 300px; height: 250px;' data-ad-client='ca-pub-3859579878880515' data-ad-slot='6905700923' data-adsbygoogle-status='done'><ins id='aswift_1_expand' style='box-sizing: inherit; display: inline-table; border: none; height: 250px; margin: 0px; padding: 0px; position: relative; visibility: visible; width: 300px; background-color: transparent;'><ins id='aswift_1_anchor' style='box-sizing: inherit; display: block; border: none; height: 250px; margin: 0px; padding: 0px; position: relative; visibility: visible; width: 300px; background-color: transparent;'><iframe id='aswift_1' style='box-sizing: inherit; max-width: 100%; left: 0px; position: absolute; top: 0px; width: 300px; height: 250px;' name='aswift_1' width='300' height='250' frameborder='0' marginwidth='0' marginheight='0' scrolling='no' allowfullscreen='true'></iframe></ins></ins></ins></div> </div> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>Hazratullah Zazai and Alex Hales will open the innings. Rashid Khan, Dwayne Bravo, James Faulkner and Roelof van der Merwe will play the role of an all-rounder.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>Rashid Khan and Roelof van der Merwe will lead the spin attack while Dwayne Bravo, James Faulkner, Zahoor Khan and R Gleeson will be the key pacers.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>They are likely to go with the same playing XI.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><span style='box-sizing: inherit; font-weight: bold;'>Northern Warriors:</span></p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>N Pooran and L Simmons will open for the side. A Russell and R Bopara will play the role of allrounders.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>Imran Haider and Chris Green will lead the spin attack while Hardus Viljoen, Wahab Riaz and Andre Russell will be the key pacers along with R Bopara.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>No changes are expected in their perfect playing XI.</p> <h2 style='box-sizing: inherit; font-family: raleway, sans-serif; font-weight: 500; line-height: 1.2; margin: 0px 0px 16px; font-size: 3rem;'>Probable Playing XI:</h2> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><span style='box-sizing: inherit; font-weight: bold;'>NOR:<br style='box-sizing: inherit;' /></span>Lendl Simmons, Nicholas Pooran (wk), Andre Russell, Rovman Powell, Ravi Bopara, Amitoze Singh, Darren Sammy (c), C Green, Wahab Riaz, Hardus Viljoen, Imran Haider.</p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><span style='box-sizing: inherit; font-weight: bold;'>MAR:<br style='box-sizing: inherit;' /></span>Hazratullah Zazai, Alex Hales, Kamran Akmal (wk), J Vince, B Taylor, Rashid Khan, Dwayne Bravo (c), James Faulkner, Roelof van der Merwe, Zahoor Khan, R Gleeson.</p> <h2 style='box-sizing: inherit; font-family: raleway, sans-serif; font-weight: 500; line-height: 1.2; margin: 0px 0px 16px; font-size: 3rem;'>MAR vs NOR Dream11 Team Prediction:<em style='box-sizing: inherit;'>&nbsp;</em></h2> <figure id='attachment_11486' class='wp-caption aligncenter' style='box-sizing: inherit; margin: 0px auto 24px; max-width: 100%; width: 639px;'><img class='wp-image-11486 size-full jetpack-lazy-image jetpack-lazy-image--handled' style='box-sizing: inherit; border-style: none; max-width: 100%; height: auto;' src='https://i0.wp.com/dreamteamcric.com/wp-content/uploads/MAR-vs-NOR-Dream11-Team-Prediction.jpeg?resize=639%2C1093&amp;ssl=1' alt='MAR vs NOR Dream11 Team Prediction' width='639' height='1093' data-recalc-dims='1' data-lazy-loaded='1' /><figcaption class='wp-caption-text' style='box-sizing: inherit; font-size: 1.4rem; font-weight: bold; margin: 0px; text-align: center;'>MAR vs NOR Dream11 Team Prediction</figcaption></figure> <h2 style='box-sizing: inherit; font-family: raleway, sans-serif; font-weight: 500; line-height: 1.2; margin: 0px 0px 16px; font-size: 3rem;'>Key Players:</h2> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><span style='box-sizing: inherit; font-weight: bold;'>Maratha Arabians:<br style='box-sizing: inherit;' /></span>Hazratullah Zazai<br style='box-sizing: inherit;' />Alex Hales<br style='box-sizing: inherit;' />Rashid Khan<br style='box-sizing: inherit;' />Dwayne Bravo<br style='box-sizing: inherit;' />R Gleeson<br style='box-sizing: inherit;' />Kamran Akmal<br style='box-sizing: inherit;' />James Faulkner<span style='box-sizing: inherit; font-weight: bold;'>&nbsp;</span></p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'><span style='box-sizing: inherit; font-weight: bold;'>Northern Warriors:<br style='box-sizing: inherit;' /></span>N Pooran<br style='box-sizing: inherit;' />Ravi Bopara<br style='box-sizing: inherit;' />Andre Russell<br style='box-sizing: inherit;' />Lendl Simmons<br style='box-sizing: inherit;' />Wahab Riaz<br style='box-sizing: inherit;' />Hardus Viljoen<br style='box-sizing: inherit;' />C Green<br style='box-sizing: inherit;' />Rovman Powell<span style='box-sizing: inherit; font-weight: bold;'>&nbsp;</span></p> <p style='box-sizing: inherit; margin: 0px 0px 26px; padding: 0px;'>If you liked&nbsp;<span style='box-sizing: inherit; font-weight: bold;'><em style='box-sizing: inherit;'>MAR vs NOR&nbsp;</em></span><em style='box-sizing: inherit;'>Dream11</em>&nbsp;prediction, then follow us on&nbsp;<u style='box-sizing: inherit;'><a style='box-sizing: inherit; background-color: inherit; transition: all 0.1s ease-in-out 0s; color: #e8554e; text-decoration-line: none;' href='https://t.me/dreamteamcricket'>Telegram</a></u>&nbsp;for Latest Cricket News and Grand League Teams.</p> </div>	<p>Tested By Rahul Kumar</p>";
            }
            var response = new HttpResponseMessage();
            response.Content = new StringContent(t_RunningMatchInfo.MatchDescription);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
            //if (t_RunningMatchInfo == null)
            //{
            //    return NotFound();
            //}

            //return Ok(response);
        }

        // PUT: api/T_RunningMatchInfo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutT_RunningMatchInfo(int id, T_RunningMatchInfo t_RunningMatchInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != t_RunningMatchInfo.ID)
            {
                return BadRequest();
            }

            db.Entry(t_RunningMatchInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!T_RunningMatchInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/T_RunningMatchInfo
        [ResponseType(typeof(T_RunningMatchInfo))]
        public async Task<IHttpActionResult> PostT_RunningMatchInfo(T_RunningMatchInfo t_RunningMatchInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.T_RunningMatchInfo.Add(t_RunningMatchInfo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = t_RunningMatchInfo.ID }, t_RunningMatchInfo);
        }

        // DELETE: api/T_RunningMatchInfo/5
        [ResponseType(typeof(T_RunningMatchInfo))]
        public async Task<IHttpActionResult> DeleteT_RunningMatchInfo(int id)
        {
            T_RunningMatchInfo t_RunningMatchInfo = await db.T_RunningMatchInfo.FindAsync(id);
            if (t_RunningMatchInfo == null)
            {
                return NotFound();
            }

            db.T_RunningMatchInfo.Remove(t_RunningMatchInfo);
            await db.SaveChangesAsync();

            return Ok(t_RunningMatchInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool T_RunningMatchInfoExists(int id)
        {
            return db.T_RunningMatchInfo.Count(e => e.ID == id) > 0;
        }
    }
}
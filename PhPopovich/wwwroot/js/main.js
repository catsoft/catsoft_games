window.UcozApp={},window.UcozApp.comments=function(){var a,b=document.querySelectorAll('.e-comments');for(a=0;a<b.length;a++){var c=b[a].innerText.match(/\d+/g);b[a].innerText=c}},UcozApp.comments(),function(a){a.fn.uNavMenu=function(){return function(){a('.navItemMore',this).length||a('.uMenuRoot',this).append('<li class="navItemMore"><div class="nav_menu_toggler"><span></span><span></span><span></span></div><ul class="overflow"></ul></li>'),a('.uMenuRoot li.navItemMore',this).before(a('.overflow > li',this));var c=a('.navItemMore',this),d=a('.uMenuRoot > li:not(.navItemMore)',this),g=c.width(),h=a('[id^="uNMenuDiv"]',this).width();for(d.each(function(){g+=a(this).width()}),g>h?c.show():c.hide();g>h&&960<window.innerWidth;)g-=d.last().width(),d.last().prependTo('.overflow',this),d.splice(-1,1);a('.uMenuRoot',this).css({overflow:'visible'})}.apply(this)}}(jQuery);var umenu=function(){$('#catmenu').uNavMenu()};$(document).ready(function(){$(function(b){var c=b('#scrollup');b(window).scroll(function(){c['fade'+(100<b(this).scrollTop()?'In':'Out')](600)})}),$('#scrollup').click(function(){return $('body,html').animate({scrollTop:0},800),!1}),$('html').has('.forumContent').addClass('forum-page'),$('#main-menu li li ul').hover(function(){$(this).parent('li').addClass('select-item')},function(){$(this).parent('li').removeClass('select-item')}),$('#sFltLst').parent('div').css('position','relative');var a=$('#uidLogForm').html();$('.loginformMobile').append(a),('invoices'==currentPageIdTemplate||'checkout'==currentPageIdTemplate||'forum'==currentModuleTemplate)&&$('table > tbody > tr > td').addClass('pageinvoices')}),$(function(a){function b(){961>window.innerWidth?(a('#catmenu li.uWithSubmenu i').each(function(){'keyboard_arrow_down'==a(this).html()&&a(this).html('add')}),a('.uMenuRoot').after(a('header .soc-block'))):(a('#catmenu li.uWithSubmenu i').html('keyboard_arrow_down'),a('.registration-links').after(a('.uMenuV .soc-block')))}a('#uNMenuDiv1').append('<div class="close-menu"><i class="material-icons">close</i></div>'),window.onresize=umenu,window.onload=umenu;var c=a('.main-menu li.uWithSubmenu');if(a('> a',c).after('<i class="material-icons menu_tog">keyboard_arrow_down</i>'),a('a[href*=\\#]').click(function(g){g.preventDefault();var h=a(this).attr('href');return a('html, body').stop().animate({scrollTop:a(h).offset().top},500,function(){location.hash=h}),!1}),(b(),a(window).resize(function(){b()}),a('> i',c).click(function(){961>window.innerWidth&&('add'==a(this).text()?(a(this).parent().addClass('over'),a(this).text('remove')):(a(this).parent().removeClass('over'),a(this).text('add')))}),a('.show-menu').on('click',function(){a('header div[id^=\'uNMenuDiv\']').toggleClass('openMenu'),a('.base').toggleClass('fixed')}),a('.goOnTop').on('click',function(g){g.preventDefault(),a('body, html').animate({scrollTop:0},1e3)}),a(document).on('click',function(g){0!==a('.uMenuRoot').has(g.target).length||a(g.target).hasClass('show-menu')||(a('header div[id^=\'uNMenuDiv\']').removeClass('openMenu'),a('.base').removeClass('fixed'))}),a('#cont-shop-invoices h1').length)){function g(h){for(var j in h)a(j).attr('title',a(j).val()).addClass('material-icons').val(h[j])}a('#cont-shop-invoices h1 + table').addClass('status_table').after('<div class="fil_togg_wrapper"><div class="fil_togg_holder"><span class="material-icons">storage</span><span class="material-icons arrow">keyboard_arrow_down</span></div></div>').siblings('table, hr').addClass('filter_table');var d={'#invoice-form-export':'file_download','#invoice-form-print':'print','#invoice-form-send-el-goods':'forward'};g(d),a(document).ajaxComplete(function(){g(d)}),a('.fil_togg_holder').on('click',function(){var h=a(this).children('.arrow');a('.filter_table').fadeToggle(),h.text('keyboard_arrow_up'==h.text()?'keyboard_arrow_down':'keyboard_arrow_up')})}a('.uTable, #order-table, #setsList').wrap('<div class="x-scroll"></div>')}),WebFontConfig={google:{families:['Cousine:400,700&subset=cyrillic,greek']},active:umenu};
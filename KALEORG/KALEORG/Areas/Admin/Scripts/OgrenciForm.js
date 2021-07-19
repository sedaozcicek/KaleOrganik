﻿/*
Name: 			Forms / Wizard - Examples
Written by: 	Okler Themes - (http://www.okler.net)
Theme Version: 	2.1.1
*/

(function ($) {

    'use strict';

	/*
	Wizard #4
	*/
    var $w4finish = $('#Student').find('ul.pager li.finish'),
        $w4validator = $("#Student form").validate({
            highlight: function (element) {
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
            },
            success: function (element) {
                $(element).closest('.form-group').removeClass('has-error');
                $(element).remove();
            },
            errorPlacement: function (error, element) {
                element.parent().append(error);
            }
        });

   

    $('#Student').bootstrapWizard({
        tabClass: 'wizard-steps',
        nextSelector: 'ul.pager li.next',
        previousSelector: 'ul.pager li.previous',
        firstSelector: null,
        lastSelector: null,
        onNext: function (tab, navigation, index, newindex) {
            var validated = $('#Student form').valid();
            if (!validated) {
                $w4validator.focusInvalid();
                return false;
            }
        },
        onTabClick: function (tab, navigation, index, newindex) {
            if (newindex == index + 1) {
                return this.onNext(tab, navigation, index, newindex);
            } else if (newindex > index + 1) {
                return false;
            } else {
                return true;
            }
        },
        onTabChange: function (tab, navigation, index, newindex) {
            var $total = navigation.find('li').length - 1;
            $w4finish[newindex != $total ? 'addClass' : 'removeClass']('hidden');
            $('#Student').find(this.nextSelector)[newindex == $total ? 'addClass' : 'removeClass']('hidden');
        },
        onTabShow: function (tab, navigation, index) {
            var $total = navigation.find('li').length - 1;
            var $current = index;
            var $percent = Math.floor(($current / $total) * 100);

            navigation.find('li').removeClass('active');
            navigation.find('li').eq($current).addClass('active');

            $('#Student').find('.progress-indicator').css({ 'width': $percent + '%' });
            tab.prevAll().addClass('completed');
            tab.nextAll().removeClass('completed');
        }
    });

}).apply(this, [jQuery]);